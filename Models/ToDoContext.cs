using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Models
{
        public class TodoContext : DbContext
        {
            public TodoContext(DbContextOptions<TodoContext> options)
                : base(options)
            {
            }

            public DbSet<TodoItem> TodoItems { get; set; }

            public DbSet<TodoApi.Models.Booking> Booking { get; set; }

            public DbSet<TodoApi.Models.Customer> Flights { get; set; }

            public DbSet<TodoApi.Models.Flights> Flight { get; set; }

            public DbSet<TodoApi.Models.Ticket> Ticket { get; set; }
        }
}
