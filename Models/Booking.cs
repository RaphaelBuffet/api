using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int IdFlight { get; set; }
        public int IdCustomers{ get; set; }
        public int IdTicket { get; set; }
    }
}
