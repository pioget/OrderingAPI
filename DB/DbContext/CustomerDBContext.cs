using Microsoft.EntityFrameworkCore;
using OrderingAPI.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;

namespace Database.context
{
 
        public sealed class CustomerDbContext : DbContext
        {
            public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
          : base(options) { }

            public DbSet<DBCustomer> customers { get; set; }

   

    
    }

        public sealed class CustomerDataGenerator
        {
            public static void Initialize(IServiceProvider serviceProvider)
            {
                using (var context = new CustomerDbContext(
                    serviceProvider.GetRequiredService<DbContextOptions<CustomerDbContext>>()))
                {
                    // Look for any board games.
                    if (context.customers.Any())
                    {
                        return;   // Data was already seeded
                    }

                    context.customers.AddRange(
                        new DBCustomer()
                        {

                            Title = "MR",
                            FirstName = "Theadore",
                            LastName = "Loagan",
                            EmailAddress = "wyldstallions@gmail.com",
                            MobileNumber = "01254557273"
                        }, new DBCustomer()
                        {

                            Title = "Mrs",
                            FirstName = "Charlotte",
                            LastName = "Johnson",
                            EmailAddress = "cjohnson@gmail.com",
                            MobileNumber = "01254883344"
                        }, new DBCustomer()
                        {

                            Title = "MR",
                            FirstName = "Elijah",
                            LastName = "Wood",
                            EmailAddress = "Ewood@Ewood.com",
                            MobileNumber = "01254667788"
                        }, new DBCustomer()
                        {

                            Title = "Mrs",
                            FirstName = "Olivia",
                            LastName = "Hall",
                            EmailAddress = "ohall@hotmail.com",
                            MobileNumber = "01254776633"
                        }, new DBCustomer()
                        {

                            Title = "MR",
                            FirstName = "James",
                            LastName = "Johnson",
                            EmailAddress = "jj@yahoo.com",
                            MobileNumber = "01254778822"
                        }, new DBCustomer()
                        {

                            Title = "MR",
                            FirstName = "Henry",
                            LastName = "Garcia",
                            EmailAddress = "sugarpuffmonster@monster.com",
                            MobileNumber = "01254778886"
                        }

                            );

                    context.SaveChanges();
                }
            }
        }
    
}
