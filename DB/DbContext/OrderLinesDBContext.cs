using Microsoft.EntityFrameworkCore;
using OrderingAPI.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.context
{
    public sealed class OrderLinesDbContext : DbContext
    {
        public OrderLinesDbContext(DbContextOptions<OrderLinesDbContext> options)
      : base(options) { }

        public DbSet<DBOrderLines> OrderLines { get; set; }
    }
}
