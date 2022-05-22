using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WahlomatNRWxml.Models
{
    public class DatenAufbereitung
    {
        public static List<Stimmen> stimmen = new List<Stimmen>();
        public static List<StimmZettelzaehler> zaehler = new List<StimmZettelzaehler>();
        public static Random rnd = new Random();
        public static Random rnd2 = new Random();

        public static void Add(Stimmen stimme)
        {
                stimmen.Add(stimme);
        }
        public static void Add1000()
        {
            for (int i = 0; i < 1000; i++)
            {
                    stimmen.Add(new Stimmen() { Erststimme = Wahldaten.spitzenKandidaten[rnd.Next(0, Wahldaten.spitzenKandidaten.Length)], Zweitstimme = Wahldaten.parteien[rnd.Next(0, Wahldaten.spitzenKandidaten.Length)] });
            }
        }
        public static void Add10000()
        {
            for (int i = 0; i < 10000; i++)
            {
                    stimmen.Add(new Stimmen() { Erststimme = Wahldaten.spitzenKandidaten[rnd.Next(0, Wahldaten.spitzenKandidaten.Length)], Zweitstimme = Wahldaten.parteien[rnd.Next(0, Wahldaten.spitzenKandidaten.Length)] });
            }
        }
        public static void Add100000()
        {
            for (int i = 0; i < 100000; i++)
            {
                    stimmen.Add(new Stimmen() { Erststimme = Wahldaten.spitzenKandidaten[rnd.Next(0, Wahldaten.spitzenKandidaten.Length)], Zweitstimme = Wahldaten.parteien[rnd.Next(0, Wahldaten.spitzenKandidaten.Length)] });
            }
        }
        public static void ClearList()
        {
            stimmen.Clear();
        }
        public static int WahlErgebnisSK(string sKandidat)
        {
            var ergebnis = from kandidat in stimmen
                           where kandidat.Erststimme == sKandidat
                           select kandidat;
            return ergebnis.Count();
        }
        public static double WahlErgebnisSKProzent(string sKandidat)
        {
            var ergebnis = from partei in stimmen
                           where partei.Erststimme == sKandidat
                           select partei;
            double prozentErgebnis = (double)ergebnis.Count() * 100 / (double)stimmen.Count();
            return Math.Round(prozentErgebnis, 2);
        }
        public static int WahlErgebnisPT(string pt)
        {
            var ergebnis = from partei in stimmen
                           where partei.Zweitstimme == pt
                           select partei;
            return ergebnis.Count();
        }
        public static double WahlErgebnisPTProzent(string pt)
        {
            var ergebnis = from partei in stimmen
                           where partei.Zweitstimme == pt
                           select partei;
            double prozentErgebnis = (double)ergebnis.Count() * 100 / (double)stimmen.Count();
            return Math.Round(prozentErgebnis, 2);
        }
        public static void ListeSpeichern()
        {
            FileStream stream = File.Create(@$"d:\wahl_nrw_liste.xml");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Stimmen>));
            xmlSerializer.Serialize(stream, stimmen);
            stream.Close();
        }
        public static void ListeSpeichernOpt()
        {
            FileStream stream = File.Create(@$"d:\wahl_nrw_liste_opt.xml");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<StimmZettelzaehler>));
            xmlSerializer.Serialize(stream, zaehler);
            stream.Close();
        }
        public static void ListeOptimieren()
        {
            zaehler.Clear();
            for (int j = 0; j < Wahldaten.spitzenKandidaten.Length; j++)
            {
                for (int i = 0; i < Wahldaten.parteien.Length; i++)
                {
                    var lindner = from lind in stimmen
                                  where lind.Erststimme == Wahldaten.spitzenKandidaten[j]
                                  where lind.Zweitstimme == Wahldaten.parteien[i]
                                  select lind;
                    zaehler.Add(new StimmZettelzaehler() { Erststimme = Wahldaten.spitzenKandidaten[j], Zweitstimme = Wahldaten.parteien[i], Zaehler = lindner.Count() });
                }
            }
        }
    }
}
