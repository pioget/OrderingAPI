using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using OrderingAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderingAPI.Repository.EFObjects
{
    public class OrderDBContext : DbContext
    {



        public OrderDBContext(DbContextOptions<OrderDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating
    (ModelBuilder modelBuilder)
        {



        }




        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> CustomerAddress { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderLines> Orderlines { get; set; }
        public DbSet<Stock> Stock { get; set; }



        public sealed class StockDataGenerator
        {
            public static void Initialize(OrderDBContext context)
            {

                // Look for any board games.
                if (context.Stock.Count() > 0)
                {
                    return;   // Data was already seeded
                }


                context.Stock.Add(new Stock("Fancy Toilet", "FNCY1", 20, 20.99m));
                context.SaveChanges();
                context.Stock.Add(new Stock("Bath", "BTH1", 200, 120.99m));
                context.SaveChanges();
                context.Stock.Add(new Stock("Shower Head", "SWRH1", 45, 39.99m));
                context.SaveChanges();
                context.Stock.Add(new Stock("Toilet Seat", "TS1", 13, 9.99m));
                context.SaveChanges();
                context.Stock.Add(new Stock("Stuff", "STFF1", 26, 200.99m));
                context.SaveChanges();


                context.SaveChanges();
            }

        }

        public sealed class CustomerDataGEnerator
        {



            public static void Initialize(OrderDBContext context)
            {

                // Look for any board games.
                if (context.Customers.Count() > 0)
                {
                    return;   // Data was already seeded
                }




                Customer cus1 = new Customer("MR", "Theadore", "Loagan", "wyldstallions@gmail.com", "01254557273");
                cus1.addsingeladdress(new Address(1, 1, "23", "Street", "Darwen", "bb3 2bw"));
                context.Customers.Add(cus1);
                context.SaveChanges();

                Customer cus2 = new Customer("Mrs", "Charlotte", "Johnson", "cjohnson@gmail.com", "01254883344");
                cus2.addsingeladdress(new Address(2, 1, "7", "Street", "Darwen", "bb3 2xw"));
                context.Customers.Add(cus2);
                context.SaveChanges();

                Customer cus3 = new Customer("MR", "Elijah", "Wood", "Ewood@Ewood.com", "01254667788");
                cus3.addsingeladdress(new Address(3, 1, "87", "Street", "Darwen", "bb3 4hg"));
                context.Customers.Add(cus3);
                context.SaveChanges();

                Customer cus4 = new Customer("Mrs", "Olivia", "Hall", "ohall@hotmail.com", "01254776633");
                cus4.addsingeladdress(new Address(4, 1, "23", "Street", "Darwen", "bb3 8jh"));
                context.Customers.Add(cus4);
                context.SaveChanges();

                Customer cus5 =new Customer("MR", "James", "Johnson", "jj@yahoo.com", "01254778822");
                cus5.addsingeladdress(new Address(5, 1, "82", "Street", "Darwen", "bb3 2gb"));
                context.Customers.Add(cus5);
                context.SaveChanges();


                //CustomerAddressDataGEnerator.Initialize(context);

            }

         
        }


    }
}
