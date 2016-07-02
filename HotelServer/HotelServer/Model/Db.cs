using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelServer.Model
{
    class Db
    {
        ICollection<Model.HotelItem> Hotels;
        ICollection<Model.HotelBuchung> HotelBuchungen;

        private static Db instance = null;

        protected Db()
        {

        }


        public static Db Instance()
        {
            if (instance == null)
            {
                instance = new Db();
                instance.Hotels = new List<Model.HotelItem>();

                instance.Hotels.Add(new HotelItem { Hotelname = "Sheraton", offeneTermine = new List<DateTime> {DateTime.Parse("2016/08/31")}, Preis = 250.00, Stadt="Berlin" });
                instance.Hotels.Add(new HotelItem { Hotelname = "Generator", offeneTermine = new List<DateTime> { DateTime.Parse("2016/08/30") }, Preis = 100.00, Stadt = "Berlin" });
                instance.Hotels.Add(new HotelItem { Hotelname = "Freudenhaus", offeneTermine = new List<DateTime> { DateTime.Parse("2016/08/29") }, Preis = 50.00, Stadt = "Berlin" });

                instance.HotelBuchungen = new List<Model.HotelBuchung>();
            }

            return instance;
        }

        public string SearchHotels(DateTime tDate, string tDestination)
        {
            try
            {
                ICollection<Model.HotelItem> HotelsInStadt = Hotels.Where(x => x.Stadt == tDestination).ToList();
                ICollection<Model.HotelItem> HotelsVerfugbar = HotelsInStadt.Where(x => x.offeneTermine.Contains(tDate)).ToList();

                return concatThatShit(HotelsVerfugbar.First());
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string concatThatShit(Model.HotelItem tHotelItem)
        {
            string res = null;

            res += tHotelItem.Hotelname;
            res += ';';
            res += tHotelItem.Preis.ToString();

            return res;
        }

        public bool bookHotel(DateTime tDateTime, string tStadt, string tHotel, double tPreis)
        {
            HotelBuchungen.Add(new HotelBuchung { Stadt = tStadt, Hotelname = tHotel, Preis = tPreis });
            return true;
        }
    }
}
