using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TodoContext(
                 serviceProvider.GetRequiredService<DbContextOptions<TodoContext>>()))
            {
                // Look for any Booking.
                if (context.Flight.Any())
                {
                    return;   // Data was already seeded
                }
                if (context.Ticket.Any())
                {
                    return;   // Data was already seeded
                }
                if (context.Customers.Any())
                {
                    return;   // Data was already seeded
                }

                context.Flight.AddRange(
                    new Flight
                    {
                        Id = 1,
                        Department = "Sion",
                        Destination = "Zurich",
                        Date = DateTime.Today.AddMonths(2),
                        Seats = 120,
                        basePrice = 120,
                        isComplete = false
                    },
                    new Flight
                    {
                        Id = 2,
                        Department = "Geneve",
                        Destination = "Zurich",
                        Date = DateTime.Today.AddMonths(2),
                        Seats = 120,
                        basePrice = 120,
                        isComplete = false
                    },
                    new Flight
                    {
                        Id = 3,
                        Department = "Zurich",
                        Destination = "Barcelone",
                        Date = DateTime.Today.AddMonths(2),
                        Seats = 120,
                        basePrice = 120,
                        isComplete = false
                    },
                    new Flight
                    {
                        Id = 4,
                        Department = "Sion",
                        Destination = "Barcelone",
                        Date = DateTime.Today.AddMonths(2),
                        Seats = 120,
                        basePrice = 120,
                        isComplete = false
                    },
                    new Flight
                    {
                        Id = 5,
                        Department = "Bale",
                        Destination = "Barcelone",
                        Date = DateTime.Today.AddMonths(2),
                        Seats = 120,
                        basePrice = 120,
                        isComplete = false
                    },
                    new Flight
                    {
                        Id = 6,
                        Department = "Zurich",
                        Destination = "Sion",
                        Date = DateTime.Today.AddMonths(2),
                        Seats = 120,
                        basePrice = 120,
                        isComplete = false
                    });
                context.Ticket.AddRange(
                     new Ticket
                     {
                         Id = 1,
                         IdFlight = 1,
                         SalePrice = 34.80
                     },
                    new Ticket
                    {
                        Id = 2,
                        IdFlight = 1,
                        SalePrice = 34.80
                    },
                    new Ticket
                    {
                        Id = 3,
                        IdFlight = 1,
                        SalePrice = 34.80
                    },
                    new Ticket
                    {
                        Id = 4,
                        IdFlight = 1,
                        SalePrice = 34.80
                    },
                    new Ticket
                    {
                        Id = 5,
                        IdFlight = 1,
                        SalePrice = 34.80
                    });

                context.Customers.AddRange(
                    new Customer
                    {
                        Id = 1,
                        Firstname = "Raphy",
                        Lastname = "Buffet",
                        IdTicket = 1
                    },
                   new Customer
                   {
                       Id = 2,
                       Firstname = "Raphy",
                       Lastname = "Buffet",
                       IdTicket = 1
                   },
                   new Customer
                   {
                       Id = 3,
                       Firstname = "Raphy",
                       Lastname = "Buffet",
                       IdTicket = 1
                   },
                   new Customer
                   {
                       Id = 4,
                       Firstname = "Raphy",
                       Lastname = "Buffet",
                       IdTicket = 1
                   },
                   new Customer
                   {
                       Id = 5,
                       Firstname = "Raphy",
                       Lastname = "Buffet",
                       IdTicket = 1
                   });
                context.SaveChanges();
            }
        }
    }
}
