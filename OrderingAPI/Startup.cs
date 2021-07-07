using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Database.context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using OrderingAPI.AppService.Services;
using OrderingAPI.Repository.Repository;
using OrderingAPI.Models.DBObjects;
using OrderingAPI.Models.DAO;

namespace OrderingAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "OrderAPI",
                    Version = "v1"
                });
            });

            services.AddDbContext<CustomerDbContext>(options => options.UseInMemoryDatabase(databaseName: "Customers"));
            services.AddDbContext<customerAddressDbContext>(options => options.UseInMemoryDatabase(databaseName: "CustomerAddress"));
            services.AddDbContext<OrderDbContext>(options => options.UseInMemoryDatabase(databaseName: "Orders"));
            services.AddDbContext<OrderLinesDbContext>(options => options.UseInMemoryDatabase(databaseName: "OrderLines"));
            services.AddDbContext<StockDbContext>(options => options.UseInMemoryDatabase(databaseName: "Stock"));



            services.AddScoped<IRepository<DBCustomer>, CustomerRepository>();
            services.AddScoped<IRepository<DBCustomerAddress>, CustomerAddressRepositry>();
            services.AddScoped<IRepository<DBOrder>, OrderRepositry>();
            services.AddScoped<IRepository<DBOrderLines>, OrderLinesRepositry>();
            services.AddScoped<IRepository<DBStock>, StockRepositry>();

            services.AddTransient<CustomerService>();
            services.AddTransient<StockService>();
            services.AddTransient<OrderService>();
            services.AddTransient<OrderLinesService>();
            services.AddTransient<CustomerAddressService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            var cultureInfo = new CultureInfo("en-GB");
            cultureInfo.NumberFormat.CurrencySymbol = "£";

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrderAPI");

            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
