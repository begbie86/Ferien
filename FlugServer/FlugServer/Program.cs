﻿using System;
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

    [ServiceContract]

    public interface IFlugbuchung
    {
        [OperationContract]
        bool bookFlug(DateTime tDateTime, string tStartStadt, string tZielstadt, double tPreis, string tFluggesellschaft);
    }

    class Flug:IFlug
    {
        public string getFlug(DateTime tDatetime, string tStartStadt, string tZielStadt)
        {
            Model.Db db = Model.Db.Instance();

            return db.SearchFlight(tDatetime, tStartStadt, tZielStadt);
        }
    }

    class FlugBuchung : IFlugbuchung
    {
        public bool bookFlug(DateTime tDateTime, string tStartStadt, string tZielstadt, double tPreis, string tFluggesellschaft)
        {
            Model.Db db = Model.Db.Instance();

            return db.bookFlight(tDateTime,tStartStadt,tZielstadt, tPreis,tFluggesellschaft);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Model.Db db = Model.Db.Instance();

            var ServiceFlugAbfragen = new ServiceHost(typeof(Flug));
            ServiceFlugAbfragen.Open();

            var ServiceFlugBuchungen = new ServiceHost(typeof(FlugBuchung));
            ServiceFlugBuchungen.Open();

            Console.WriteLine("FlugService running.");
            Console.ReadLine();
        }
    }
}
