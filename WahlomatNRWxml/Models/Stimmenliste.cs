//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace WahlomatNRWxml.Models
//{
//        public class Stimmenliste
//        {
//            public Dictionary<Stimme, int> Kumuliert { get; } = new Dictionary<Stimme, int>();
//            public int StimmenGesamt { get => Kumuliert.Values.Sum(); }
//            public int StimmenUnique { get => Kumuliert.Count(); }

//            public Stimmenliste(List<Stimme> stimmen)
//            {
//                foreach (Stimme stimme in stimmen)
//                {
//                    if (Kumuliert.ContainsKey(stimme))
//                    {
//                        Kumuliert[stimme]++;
//                    }
//                    else
//                    {
//                        Kumuliert[stimme] = 1;
//                    }
//                }
//            }
//            public Stimmenliste() { }
//        }

//    }

