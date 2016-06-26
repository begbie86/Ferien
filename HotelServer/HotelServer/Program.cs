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

    class Hotel:IHotel
    {
        public string getHotel(DateTime tDate, string tDestination)
        {
            Model.Db db = Model.Db.Instance();

            return db.SearchHotels(tDate, tDestination);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Model.Db db = Model.Db.Instance();

            var ServiceHostHotels = new ServiceHost(typeof(Hotel));
            ServiceHostHotels.Open();

            Console.WriteLine("HotelService Running...");
            Console.ReadLine();
        }
    }
}
