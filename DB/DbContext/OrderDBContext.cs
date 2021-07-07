using Microsoft.EntityFrameworkCore;
using OrderingAPI.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.context
{
    public sealed class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
      : base(options) { }

        public DbSet<DBOrder> Orders { get; set; }
    }
}
