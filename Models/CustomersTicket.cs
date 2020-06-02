using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class CustomersTicket
    {
        public int IdTicket { get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public int IdFlight { get; set; }
        public int TicketPrice { get; set; }

    }
}
