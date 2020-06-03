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
    public class FlightController : ControllerBase
    {
        private readonly TodoContext _context;

        public FlightController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Flight
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flight>>> GetAllFlight()
        {
            return await _context.Flight.ToListAsync();
        }

        // GET: api/Flight/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetFlight(int id)
        {
            var flight = await _context.Flight.FindAsync(id);

            if (flight == null)
            {
                return NotFound();
            }

            return flight;
        }
        // GET: api/Flight/available
        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<Flight>>> GetAllFlightAvailable()
        {
            return await _context.Flight
                .Where(x =>x.isComplete == false)
                .ToListAsync();
        }
        // GET: api/Flight/Price
        [HttpGet("Price/{id}")]
        public async Task<ActionResult<double>> GetFlightPrice(int id)
        {
            var flight = await _context.Flight.FindAsync(id);
            var tickets = await _context.Ticket
                .Where(x=> x.IdFlight==id)
                .ToListAsync();
            DateTime LimitDate = DateTime.Now;

            if (flight == null)
            {
                return NotFound();
            }
            if (flight.Seats * 0.8 < tickets.Count)
            {
                return flight.basePrice * 1.5;
            }
            LimitDate.AddMonths(1);
            if (flight.Seats *0.5> tickets.Count && flight.Date < LimitDate)
            {
                return flight.basePrice * 0.7;
            }
            LimitDate.AddMonths(1);
            if (flight.Seats * 0.2 > tickets.Count && flight.Date < LimitDate)
            {
                return flight.basePrice * 0.8;
            }

            return flight.basePrice;
        }
        // POST: api/Flight
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        [HttpPost]
        public async Task<ActionResult<Flight>> PostFlight(Flight flight)
        {
            _context.Flight.Add(flight);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlight", new { id = flight.Id }, flight);
        }
    }
}
