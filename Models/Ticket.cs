using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int IdFlight { get; set; }
        public double SalePrice { get; set; }
    }
}
