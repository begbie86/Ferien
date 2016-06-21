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

namespace ClientWPF.Control
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


    class ClientController
    {
        DynamicEndpoint dynamicFlugEndpoint;
        DynamicEndpoint dynamicHotelEndpoint;



        public ClientController()
        {
            dynamicFlugEndpoint = new DynamicEndpoint(ContractDescription.GetContract(typeof(IFlug)), new WSHttpBinding(SecurityMode.None));
            dynamicHotelEndpoint = new DynamicEndpoint(ContractDescription.GetContract(typeof(IHotel)), new WSHttpBinding(SecurityMode.None));

            var proxyFlug = new ChannelFactory<IFlug>(dynamicFlugEndpoint).CreateChannel();
            var proxyHotel = new ChannelFactory<IHotel>(dynamicHotelEndpoint).CreateChannel();
        }


        public string Feriensuche(DateTime tDT, string tStartStadt, string tZielStadt)
        {
            var proxyFlug = new ChannelFactory<IFlug>(dynamicFlugEndpoint).CreateChannel();

            return proxyFlug.getFlug(tDT, tStartStadt, tZielStadt);
        }

        public string Hotelsuche(DateTime tDT, string tZielStadt)
        {
            var proxyHotel = new ChannelFactory<IHotel>(dynamicHotelEndpoint).CreateChannel();

            return proxyHotel.getHotel(tDT, tZielStadt);
        }
    }
}
