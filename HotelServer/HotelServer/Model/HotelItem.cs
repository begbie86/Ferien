using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelServer.Model
{

    public class HotelItem
    {
        public int Id { get; set; }
        public string Hotelname { get; set; }
        public string Stadt { get; set; }
        public ICollection<DateTime> offeneTermine { get; set; }
        public double Preis { get; set; }
    }
}
