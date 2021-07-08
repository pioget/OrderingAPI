using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using static OrderingAPI.Repository.EFObjects.OrderDBContext;

namespace OrderingAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();

            IWebHost BuildWebHost = WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();

            createscope(BuildWebHost);


            BuildWebHost.Run();
        }

        private static void createscope(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {

                var services = scope.ServiceProvider;
               
                //CustomerDataGEnerator.Initialize(services);
                //CustomerAddressDataGEnerator.Initialize(services);
                //StockDataGenerator.Initialize(services);
              
            }
        }

      //  public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
      //      WebHost.CreateDefaultBuilder(args)
      //          .UseStartup<Startup>();
    }
}
