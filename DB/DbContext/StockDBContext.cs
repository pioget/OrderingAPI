using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderingAPI.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database.context
{
    public sealed class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions<StockDbContext> options)
      : base(options) { }

        public DbSet<DBStock> Stock { get; set; }
    }

    public sealed class StockDataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StockDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<StockDbContext>>()))
            {
                // Look for any board games.
                if (context.Stock.Any())
                {
                    return;   // Data was already seeded
                }

                context.Stock.AddRange(
                    new DBStock()
                    {

                        ItemDescritpion = "Fancy Toilet",
                        StockQuantity = 20,
                        SKUcode = "FNCY1",
                        Price = 20.99m,
                        IsActive = true

                    },
                      new DBStock()
                      {

                          ItemDescritpion = "Bath",
                          StockQuantity = 11,
                          SKUcode = "BTH1",
                          Price = 89.99m,
                          IsActive = true

                      },
                        new DBStock()
                        {

                            ItemDescritpion = "Shower Head",
                            StockQuantity = 20,
                            SKUcode = "SHWR1",
                            Price = 16.99m,
                            IsActive = true

                        },
                          new DBStock()
                          {

                              ItemDescritpion = "Toilet Seat",
                              StockQuantity = 5,
                              SKUcode = "TSCP1",
                              Price = 8.99m,
                              IsActive = true

                          },
                            new DBStock()
                            {

                                ItemDescritpion = "Stuff",
                                StockQuantity = 20,
                                SKUcode = "STF1",
                                Price = 43.99m,
                                IsActive = true

                            }

                        );

                context.SaveChanges();
            }
        }
    }
}
