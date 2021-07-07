using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderingAPI.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database.context
{
    public sealed class customerAddressDbContext : DbContext
    {
        public customerAddressDbContext(DbContextOptions<customerAddressDbContext> options)
      : base(options) { }

        public DbSet<DBCustomerAddress> customeraddresses { get; set; }
    }

    public sealed class CustomerAddressDataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new customerAddressDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<customerAddressDbContext>>()))
            {
                // Look for any board games.
                if (context.customeraddresses.Any())
                {
                    return;   // Data was already seeded
                }

                context.customeraddresses.AddRange(
                    new DBCustomerAddress()
                    {

                        CustomerID = 1,
                        Address1 = "23",
                        Address2 = "Avenue",
                        Town = "Street",
                        Postcode = "BB1 2JD"

                    }, new DBCustomerAddress()
                    {

                        CustomerID = 2,
                        Address1 = "45",
                        Address2 = "Star",
                        Town = "Bolton",
                        Postcode = "BL3 3VD"
                    }, new DBCustomerAddress()
                    {

                        CustomerID = 3,
                        Address1 = "45",
                        Address2 = "Town",
                        Town = "Bolton",
                        Postcode = "BL5 2XY"
                    }, new DBCustomerAddress()
                    {

                        CustomerID = 4,
                        Address1 = "45",
                        Address2 = "turncroft road",
                        Town = "Darwen",
                        Postcode = "BB4 3JY"
                    }, new DBCustomerAddress()
                    {

                        CustomerID = 5,
                        Address1 = "54",
                        Address2 = "Something street",
                        Town = "Blackburn",
                        Postcode = "BB5 5JD"
                    }, new DBCustomerAddress()
                    {

                        CustomerID = 6,
                        Address1 = "64",
                        Address2 = "Pretzel Road",
                        Town = "Font",
                        Postcode = "bb4 4bn"
                    }

                        );

                context.SaveChanges();
            }
        }
    }
}
