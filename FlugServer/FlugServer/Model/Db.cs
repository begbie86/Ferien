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

                    instance.Flights.Add(new FlugItem { Id = 1, Preis = 40.00, StartStadt = "Bern", Zielstadt = "Berlin", Datum = new DateTime(2016,08,31) });
                    instance.Flights.Add(new FlugItem { Id = 2, Preis = 210.00, StartStadt = "Bern", Zielstadt = "Berlin", Datum = new DateTime(2016,08,30) });
                    instance.Flights.Add(new FlugItem { Id = 3, Preis = 150.00, StartStadt = "Bern", Zielstadt = "Berlin", Datum = new DateTime(2016,08,29) });
                }

                return instance;
        }
    }
}
