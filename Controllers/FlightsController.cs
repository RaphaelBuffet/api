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
    [Route("api/Flight")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly TodoContext _context;

        public FlightsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Flights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flights>>> GetAllFlight()
        {
            return await _context.Flight.ToListAsync();
        }

        // GET: api/Flights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Flights>> GetFlight(int id)
        {
            var flight = await _context.Flight.FindAsync(id);

            if (flight == null)
            {
                return NotFound();
            }

            return flight;
        }
        // GET: api/Flights/available
        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<Flights>>> GetAllFlight(Boolean available)
        {
            return await _context.Flight
                .Where(i =>i.isComplete == false)
                .ToListAsync();
        }
        // GET: api/Flights/Price
        [HttpGet("Price/{id}")]
        public async Task<ActionResult<double>> GetFlightPrice(int id)
        {
            var flight = await _context.Flight.FindAsync(id);
            var tickets = await _context.Ticket
                .Where(x=> x.IdFlight==id)
                .ToListAsync();
            var price = flight.basePrice;
            var nbticket = tickets.Count;
            DateTime LimitDate = DateTime.Now;
            if (flight == null)
            {
                return NotFound();
            }
            if (flight.Seats * 0.8 < nbticket)
            {
                return price * 1.5;
            }
            LimitDate.AddMonths(1);
            if (flight.Seats *0.5> nbticket && flight.Date < LimitDate)
            {
                return price * 0.7;
            }
            LimitDate.AddMonths(1);
            if (flight.Seats * 0.2 > nbticket && flight.Date < LimitDate)
            {
                return price * 0.8;
            }

            return price;
        }
        // POST: api/Flight
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        [HttpPost]
        public async Task<ActionResult<Flights>> PostFlight(Flights flights)
        {
            _context.Flight.Add(flights);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlight", new { id = flights.Id }, flights);
        }
    }
}
