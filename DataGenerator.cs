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
                        Date = DateTime.Today.AddMonths(4).AddDays(1),
                        Seats = 120,
                        basePrice = 120,
                        isComplete = true
                    },
                    new Flight
                    {
                        Id = 2,
                        Department = "Geneve",
                        Destination = "Zurich",
                        Date = DateTime.Today.AddMonths(2).AddDays(1),
                        Seats = 10,
                        basePrice = 100,
                        isComplete = false
                    },
                    new Flight
                    {
                        Id = 3,
                        Department = "Zurich",
                        Destination = "Barcelone",
                        Date = DateTime.Today.AddMonths(1).AddDays(1),
                        Seats = 20,
                        basePrice = 100,
                        isComplete = false
                    },
                    new Flight
                    {
                        Id = 4,
                        Department = "Sion",
                        Destination = "Barcelone",
                        Date = DateTime.Today.AddDays(1),
                        Seats = 30,
                        basePrice = 100,
                        isComplete = false
                    },
                    new Flight
                    {
                        Id = 5,
                        Department = "Bale",
                        Destination = "Barcelone",
                        Date = DateTime.Today.AddMonths(2).AddDays(1),
                        Seats = 90,
                        basePrice = 90,
                        isComplete = false
                    },
                    new Flight
                    {
                        Id = 6,
                        Department = "Zurich",
                        Destination = "Sion",
                        Date = DateTime.Today.AddMonths(3).AddDays(7),
                        Seats = 70,
                        basePrice = 80,
                        isComplete = false
                    });
                context.Ticket.AddRange(
                     new Ticket
                     {
                         Id = 1,
                         IdFlight = 2,
                         SalePrice = 100
                     },
                    new Ticket
                    {
                        Id = 2,
                        IdFlight = 2,
                        SalePrice = 100
                    },
                    new Ticket
                    {
                        Id = 3,
                        IdFlight = 2,
                        SalePrice = 100
                    },
                    new Ticket
                    {
                        Id = 4,
                        IdFlight = 2,
                        SalePrice = 100
                    },
                    new Ticket
                    {
                        Id = 5,
                        IdFlight = 2,
                        SalePrice = 100
                    },
                    new Ticket
                    {
                        Id = 6,
                        IdFlight = 2,
                        SalePrice = 100
                    },
                    new Ticket
                    {
                        Id = 7,
                        IdFlight = 2,
                        SalePrice = 100
                    },
                    new Ticket
                    {
                        Id = 8,
                        IdFlight = 2,
                        SalePrice = 100
                    },
                    new Ticket
                    {
                        Id = 9,
                        IdFlight = 2,
                        SalePrice = 150
                    },
                    new Ticket
                    {
                        Id = 10,
                        IdFlight = 1,
                        SalePrice = 120
                    },
                    new Ticket
                    {
                        Id = 11,
                        IdFlight = 3,
                        SalePrice = 80
                    },
                    new Ticket
                    {
                        Id = 12,
                        IdFlight = 4,
                        SalePrice = 70
                    },
                    new Ticket
                    {
                        Id = 13,
                        IdFlight = 5,
                        SalePrice = 90
                    },
                    new Ticket
                    {
                        Id = 14,
                        IdFlight = 6,
                        SalePrice = 80
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
                       Firstname = "Loan",
                       Lastname = "Buffet",
                       IdTicket = 2
                   },
                   new Customer
                   {
                       Id = 3,
                       Firstname = "Melissa",
                       Lastname = "Buffet",
                       IdTicket = 3
                   },
                   new Customer
                   {
                       Id = 4,
                       Firstname = "Mathieu",
                       Lastname = "Buffet",
                       IdTicket = 4
                   },
                   new Customer
                   {
                       Id = 5,
                       Firstname = "Raymond",
                       Lastname = "Buffet",
                       IdTicket = 5
                   },
                   new Customer
                   {
                       Id = 6,
                       Firstname = "Muriel",
                       Lastname = "Buffet",
                       IdTicket = 6
                   },
                   new Customer
                   {
                       Id = 7,
                       Firstname = "George",
                       Lastname = "Michaud",
                       IdTicket = 7
                   },
                   new Customer
                   {
                       Id = 8,
                       Firstname = "Madeleine",
                       Lastname = "Michaud",
                       IdTicket = 8
                   },
                   new Customer
                   {
                       Id = 9,
                       Firstname = "Alain",
                       Lastname = "Michaud",
                       IdTicket = 9
                   },
                   new Customer
                   {
                       Id = 10,
                       Firstname = "Chantal",
                       Lastname = "Buffet",
                       IdTicket = 10
                   },
                   new Customer
                   {
                       Id = 11,
                       Firstname = "Christine",
                       Lastname = "Michaud",
                       IdTicket = 11
                   },
                   new Customer
                   {
                       Id = 12,
                       Firstname = "Michel",
                       Lastname = "Buffet",
                       IdTicket = 12
                   },
                   new Customer
                   {
                       Id = 13,
                       Firstname = "André",
                       Lastname = "Buffet",
                       IdTicket = 13
                   },
                   new Customer
                   {
                       Id = 14,
                       Firstname = "Jean-René",
                       Lastname = "Buffet",
                       IdTicket = 14
                   });
                context.SaveChanges();
            }
        }
    }
}
