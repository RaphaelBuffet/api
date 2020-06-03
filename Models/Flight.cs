using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string Department { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }
        public int Seats { get; set; }
        public double basePrice { get; set; }
        public Boolean isComplete { get; set; }
    }
}
