using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tesodev.Case.Customer.Application.Handlers;
using Tesodev.Case.Customer.Infrastructure;
using Tesodev.Case.Shared.Constant;

namespace Tesodev.Case.Customer.API
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

            services.AddDbContext<CustomerDbContext>(opt =>
            {
                opt.UseNpgsql(ConnectionStrings.CustomerDbConnectionString, configure =>
                {
                    configure.MigrationsAssembly("Tesodev.Case.Customer.Infrastructure");
                });
            });
            //services.AddMassTransitHostedService();

            services.AddHttpContextAccessor();

            services.AddMediatR(typeof(CreateCustomerCommandHandler).Assembly);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
