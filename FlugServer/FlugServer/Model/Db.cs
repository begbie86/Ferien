using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlugServer.Model
{
    public class Db
    {
        ICollection<Model.FlugItem> Flights;
        ICollection<Model.FlugBuchung> Buchungen;


        private static Db instance = null;
        protected Db()
        {

        }

        public static Db Instance()
        {
                if (instance == null)
                {
                    instance = new Db();

                    instance.Flights = new List<Model.FlugItem>();

                    instance.Flights.Add(new FlugItem { Id = 1, Preis = 40.00, StartStadt = "Bern", Zielstadt = "Berlin", Datum = new DateTime(2016,08,31), Fluggesellschaft = "Airberlin" });
                    instance.Flights.Add(new FlugItem { Id = 2, Preis = 210.00, StartStadt = "Bern", Zielstadt = "Berlin", Datum = new DateTime(2016,08,30), Fluggesellschaft = "Swiss" });
                    instance.Flights.Add(new FlugItem { Id = 3, Preis = 150.00, StartStadt = "Bern", Zielstadt = "Berlin", Datum = new DateTime(2016,08,29), Fluggesellschaft = "Kongo Air" });

                    instance.Buchungen = new List<FlugBuchung>();
                }

                return instance;
        }


        //OK nicht so schön, dafür funktionierts :)
        public string SearchFlight(DateTime tDT, string tStartStadt, string tZielStadt)
        {
            try
            {
                ICollection<Model.FlugItem> StartItems = Flights.Where(x => x.StartStadt == tStartStadt).ToList();
                ICollection<Model.FlugItem> Blabla = StartItems.Where(x => x.Zielstadt == tZielStadt).ToList();
                ICollection<Model.FlugItem> EndResult = Blabla.Where(x => x.Datum == tDT).ToList();

                return concatThatShit(EndResult.First());
            }
            catch (Exception)
            {
                return "NULL";
            }
        }

        public string concatThatShit(Model.FlugItem tFlugItem)
        {
            string res = null;

            res += tFlugItem.Fluggesellschaft;
            res += ';';
            res += tFlugItem.Preis.ToString();

            return res;
        }

        public bool bookFlight(DateTime tDateTime, string tStartStadt, string tZielstadt, double tPreis, string tFluggesellschaft)
        {
            Buchungen.Add(new FlugBuchung { Fluggesellschaft = tFluggesellschaft, Datum = tDateTime, Preis = tPreis, StartStadt = tStartStadt, Zielstadt = tZielstadt });
            return true;
        }
    }
}
