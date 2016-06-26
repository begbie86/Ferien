using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Zusätzliche Namespaces
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Discovery;

namespace HotelServer
{
    [ServiceContract]
    public interface IHotel
    {
        [OperationContract]
        string getHotel(DateTime tDate, string tDestination);
    }

    [ServiceContract]
    public interface IHotelBuchung
    {
        [OperationContract]
        bool bookHotel(DateTime tDate, string tHotelName, string tDestination, double tPreis);
    }

    class Hotel:IHotel
    {
        public string getHotel(DateTime tDate, string tDestination)
        {
            Model.Db db = Model.Db.Instance();

            return db.SearchHotels(tDate, tDestination);
        }
    }

    class HotelBuchung:IHotelBuchung
    {
        public bool bookHotel(DateTime tDate, string tHotelName, string tDestination, double tPreis)
        {
            Model.Db db = Model.Db.Instance();
            return db.bookHotel(tDate, tDestination, tHotelName, tPreis);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Model.Db db = Model.Db.Instance();

            var ServiceHostHotels = new ServiceHost(typeof(Hotel));
            ServiceHostHotels.Open();

            var ServiceHostHotelBuchung = new ServiceHost(typeof(HotelBuchung));
            ServiceHostHotelBuchung.Open();

            Console.WriteLine("HotelService Running...");
            Console.ReadLine();
        }
    }
}
