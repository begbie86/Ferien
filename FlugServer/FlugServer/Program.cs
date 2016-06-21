using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace FlugServer
{
    [ServiceContract]
    public interface IFlug
    {
        [OperationContract]
        string getFlug(DateTime tDatetime, string tStartStadt, string tZielStadt);
    }

    class Flug:IFlug
    {
        public string getFlug(DateTime tDatetime, string tStartStadt, string tZielStadt)
        {
            return "31.08.2016;Bern;Berlin;250";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Model.Db db = Model.Db.Instance();

            var ServiceFlugAbfragen = new ServiceHost(typeof(Flug));
            ServiceFlugAbfragen.Open();

            Console.WriteLine("FlugService running.");
            Console.ReadLine();
        }
    }
}
