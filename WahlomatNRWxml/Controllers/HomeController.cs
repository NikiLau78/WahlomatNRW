using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WahlomatNRWxml.Models;

namespace WahlomatNRWxml.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
       
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public ViewResult Waehlen()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Waehlen(Stimmen stimmen)
        {
            ModelState.Clear();
            DatenAufbereitung.Add(stimmen);
            return View("Waehlen", new Stimmen());
        }
        public ViewResult Waehlen1000()
        {
            ModelState.Clear();
            DatenAufbereitung.Add1000();
            return View("Waehlen", new Stimmen());
        }
        public ViewResult Waehlen10000()
        {
            ModelState.Clear();
            DatenAufbereitung.Add10000();
            return View("Waehlen", new Stimmen());
        }
        public ViewResult Waehlen100000()
        {
            ModelState.Clear();
            DatenAufbereitung.Add100000();
            return View("Waehlen", new Stimmen());
        }
        public ViewResult ClearList()
        {
            ModelState.Clear();
            DatenAufbereitung.ClearList();
            return View("Waehlen", new Stimmen());
        }

        public ViewResult Auswertung()
        {
            return View();
        }
        public ViewResult ListeVerschickt()
        {
            DatenAufbereitung.ListeOptimieren();
            DatenAufbereitung.ListeSpeichernOpt();
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
