using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

using OrderingAPI.Repository.Interfaces;
using OrderingAPI.Repository.LocalRepoistory;


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

            //services.AddDbContext<CustomerDbContext>(options => options.UseInMemoryDatabase(databaseName: "Customers"));
            //services.AddDbContext<customerAddressDbContext>(options => options.UseInMemoryDatabase(databaseName: "CustomerAddress"));
            //services.AddDbContext<OrderDbContext>(options => options.UseInMemoryDatabase(databaseName: "Orders"));
            //services.AddDbContext<OrderLinesDbContext>(options => options.UseInMemoryDatabase(databaseName: "OrderLines"));
            //services.AddDbContext<StockDbContext>(options => options.UseInMemoryDatabase(databaseName: "Stock"));

            //services.AddDbContext<Models.EFObjects.OrderDBContext>();

            services.AddDbContext<Repository.EFObjects.OrderDBContext>(options =>
options.UseSqlServer("Data Source=(localdb)\\NewInstance;Initial Catalog=OrderingAPI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));

            //services.AddScoped<IRepository<DBCustomer>, CustomerRepository>();
            //services.AddScoped<IRepository<DBCustomerAddress>, CustomerAddressRepositry>();
            //services.AddScoped<IRepository<DBOrder>, OrderRepositry>();
            //services.AddScoped<IRepository<DBOrderLines>, OrderLinesRepositry>();
            //services.AddScoped<IRepository<DBStock>, StockRepositry>();

            services.AddScoped<IRepository<Repository.EFObjects.Customer>, Repository.LocalRepoistory.CustomerRepository>();
            services.AddScoped<IRepository<Repository.EFObjects.Address>, Repository.LocalRepoistory.CustomerAddressRepository>();
            services.AddScoped<IRepository<Repository.EFObjects.Order>, Repository.LocalRepoistory.OrderRepository>();
            services.AddScoped<IRepository<Repository.EFObjects.OrderLines>, Repository.LocalRepoistory.OrderLineRepository>();
            services.AddScoped<IRepository<Repository.EFObjects.Stock>, Repository.LocalRepoistory.StockRepository>();


            services.AddScoped<IUnitOfWork<Repository.EFObjects.Customer>, UnitOfWork<Repository.EFObjects.Customer>>();
            services.AddScoped<IUnitOfWork<Repository.EFObjects.Address>, UnitOfWork<Repository.EFObjects.Address>>();
            services.AddScoped<IUnitOfWork<Repository.EFObjects.Order>, UnitOfWork<Repository.EFObjects.Order>>();
            services.AddScoped<IUnitOfWork<Repository.EFObjects.OrderLines>, UnitOfWork<Repository.EFObjects.OrderLines>>();
            services.AddScoped<IUnitOfWork<Repository.EFObjects.Stock>, UnitOfWork<Repository.EFObjects.Stock>>();

        


            services.AddTransient<CustomerService>();
            services.AddTransient<StockService>();
            services.AddTransient<OrderService>();
            services.AddTransient<OrderLinesService>();
            services.AddTransient<CustomerAddressService>();
            services.AddTransient<CustomerService>();



            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Repository.EFObjects.OrderDBContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            db.Database.EnsureCreated();

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
