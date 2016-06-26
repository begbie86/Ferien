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

    [ServiceContract]
    public interface IFlugbuchung
    {
        [OperationContract]
        bool bookFlug(DateTime tDateTime, string tStartStadt, string tZielstadt, double tPreis, string tFluggesellschaft);
    }

    [ServiceContract]
    public interface IHotelBuchung
    {
        [OperationContract]
        bool bookHotel(DateTime tDate, string tHotelName, string tDestination, double tPreis);
    }



    class ClientController
    {
        DynamicEndpoint dynamicFlugEndpoint;
        DynamicEndpoint dynamicHotelEndpoint;
        DynamicEndpoint dynamicFlugBuchungEndpoint;
        DynamicEndpoint dynamicHotelBuchungEndpoint;



        public ClientController()
        {
            dynamicFlugEndpoint = new DynamicEndpoint(ContractDescription.GetContract(typeof(IFlug)), new WSHttpBinding(SecurityMode.None));
            dynamicHotelEndpoint = new DynamicEndpoint(ContractDescription.GetContract(typeof(IHotel)), new WSHttpBinding(SecurityMode.None));
            dynamicFlugBuchungEndpoint = new DynamicEndpoint(ContractDescription.GetContract(typeof(IFlugbuchung)), new WSHttpBinding(SecurityMode.None));
            dynamicHotelBuchungEndpoint = new DynamicEndpoint(ContractDescription.GetContract(typeof(IHotelBuchung)), new WSHttpBinding(SecurityMode.None));
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

        public bool FlugBuchung(DateTime tDateTime, string tStartStadt, string tZielstadt, double tPreis, string tFluggesellschaft)
        {
            var proxyFlugBuchung = new ChannelFactory<IFlugbuchung>(dynamicFlugBuchungEndpoint).CreateChannel();

            return proxyFlugBuchung.bookFlug(tDateTime, tStartStadt, tZielstadt, tPreis, tFluggesellschaft);
        }

        public bool HotelBuchung(DateTime tDate, string tHotelName, string tDestination, double tPreis)
        {
            var proxyHotelBuchung = new ChannelFactory<IHotelBuchung>(dynamicHotelBuchungEndpoint).CreateChannel();

            return proxyHotelBuchung.bookHotel(tDate, tHotelName, tDestination, tPreis);
        }
    }
}
