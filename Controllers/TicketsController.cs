using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/Tickets")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly TodoContext _context;

        public TicketsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicket()
        {
            return await _context.Ticket.ToListAsync();
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicketbyId(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return ticket;
        }
        // GET: api/Tickets/Price/Sum/2
        [HttpGet("Price/Sum/{idFlight}")]
        public async Task<ActionResult<double>> GetTotalPrice(int idFlight)
        {
            var tickets = await _context.Ticket
                .Where(x => x.IdFlight == idFlight)
                .ToListAsync();
            var sum = 0.0;
            for (int i = 0; i < tickets.Count; i++)
            {
                sum += tickets[i].SalePrice;
            }
            return sum;
        }
        [HttpGet("Price/Avg/{destination}")]
        public async Task<ActionResult<double>> GetAveragePrice(String destination)
        {
            var tickets = await _context.Ticket.ToListAsync();
            Console.WriteLine(destination);
           
            var flights = await _context.Flight
                .Where(x => x.Destination == destination)
                .ToListAsync();
            var sum = 0.0;
            tickets.Clear();
            for (int i = 0; i < flights.Count; i++)
            {
                var tempticket = await _context.Ticket
                    .Where(x => x.IdFlight == flights[i].Id)
                    .ToListAsync();
                for (int j = 0; j < tempticket.Count; j++)
                {
                    tickets.Add(tempticket[j]);
                }
            }
            for (int i = 0; i < tickets.Count; i++)
            {
                sum += tickets[i].SalePrice;
            }
            if (tickets.Count == 0)
            {
                return NotFound();
            }

            return sum / tickets.Count;
        }

        // GET: api/Tickets/destination
        [HttpGet("destination/{destination}")]
        public async Task<ActionResult<IEnumerable<CustomersTicket>>> GetTicketbyDestination(String destination)
        {
            var flights = await _context.Flight
                .Where(x => x.Destination == destination)
                .ToListAsync();
            var CustomersTicket = await _context.CustomersTicket.ToListAsync();
            for (int i = 0; i < flights.Count; i++)
            {
                var tempticket = await _context.Ticket
                    .Where(x => x.IdFlight == flights[i].Id)
                    .ToListAsync();
                for (int j = 0; j < tempticket.Count; j++)
                {
                    var tempcustomers = await _context.Customers
                        .Where(x => x.IdTicket == tempticket[j].Id)
                        .ToListAsync();
                    CustomersTicket.Add(CustomerTicketChange(tempticket[j], tempcustomers[0]));
                }
            }
            return CustomersTicket;
        }

        // POST: api/Tickets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket)
        {
            var price = ticket.SalePrice;
            var flight = await _context.Flight.FindAsync(ticket.IdFlight);
            var tickets = await _context.Ticket
                .Where(x => x.IdFlight == ticket.IdFlight)
                .ToListAsync();
            DateTime LimitDate = DateTime.Today;

            if (flight == null)
            {
                return NotFound();
            }
            if (flight.Seats * 0.8 < tickets.Count)
            {
                price= flight.basePrice * 1.5;
            }
            LimitDate = LimitDate.AddMonths(1);
            if (flight.Seats * 0.5 > tickets.Count && flight.Date < LimitDate)
            {
                price = flight.basePrice * 0.7;
            }
            LimitDate = LimitDate.AddMonths(1);
            if (flight.Seats * 0.2 > tickets.Count && flight.Date < LimitDate)
            {
                price = flight.basePrice * 0.8;
            }
            _context.Ticket.Add(
                
                new Ticket
                {
                    IdFlight = ticket.IdFlight,
                    SalePrice= price
                });
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicket", new { id = ticket.Id }, ticket);
        }
        private static CustomersTicket CustomerTicketChange(Ticket ticket,Customer customer) =>
            new CustomersTicket
            {
                Id=ticket.Id,
                Firstname = customer.Firstname,
                Lastname = customer.Lastname,
                IdFlight = ticket.IdFlight,
                TicketPrice = ticket.SalePrice
            };
        
    }
}
