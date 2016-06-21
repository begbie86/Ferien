﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlugServer.Model
{
    public class FlugItem
    {
        public int Id { get; set; }
        public string StartStadt { get; set; }
        public string Zielstadt { get; set; }
        public string Fluggesellschaft { get; set; }
        public DateTime Datum { get; set; }
        public double Preis { get; set; }
    }
}
