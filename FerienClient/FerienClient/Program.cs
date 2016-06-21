using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Zusätzliche Namespaces
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.ServiceModel.Discovery;

namespace FerienClient
{
    [ServiceContract]
    public interface IFlug
    {
        [OperationContract]
        string getFlug(DateTime tDatetime, string tStartStadt, string tZielStadt);
    }

    [ServiceContract]
    public interface IHotel
    {
        [OperationContract]
        string getHotel(DateTime tDate, string tDestination);
    }
    

    class Program
    {
        static void Main(string[] args)
        {
            var dynamicFlugEndpoint = new DynamicEndpoint(ContractDescription.GetContract(typeof(IFlug)), new WSHttpBinding(SecurityMode.None));
            var dynamicHotelEndpoint = new DynamicEndpoint(ContractDescription.GetContract(typeof(IHotel)), new WSHttpBinding(SecurityMode.None));

            var proxyFlug = new ChannelFactory<IFlug>(dynamicFlugEndpoint).CreateChannel();
            var proxyHotel = new ChannelFactory<IHotel>(dynamicHotelEndpoint).CreateChannel();

            Console.WriteLine("Wohin wollen Sie wann gehen?");
            DateTime dt = new DateTime(2016, 08, 31);

            Console.WriteLine(proxyFlug.getFlug(dt,"Bern","Berlin"));
            Console.WriteLine(proxyHotel.getHotel(dt, "Berlin"));

            Console.ReadKey();
        }
    }
}
