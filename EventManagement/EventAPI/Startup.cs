using EventAPI.Data;
using EventAPI.Massaging.Consumers;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI
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
            services.AddControllers();
            var dbServer = Configuration["DatabaseServer"];
            var dbName = Configuration["DatabaseName"];
            var dbUser = Configuration["DatabaseUser"];
            var dbPwd = Configuration["DatabasePassword"];
            var ConnectionString = $"Data Source={dbServer};Initial Catalog={dbName};User Id={dbUser};Password={dbPwd};Connect Timeout=30;";
            
            services.AddDbContext<EventCatalogContext>(options => options.UseSqlServer(ConnectionString));
            services.AddSwaggerGen(options =>
                            {
                                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                                {
                                    Title = "EventManagement - Event API",
                                    Version = "v1",
                                    Description = "Event API Microservice"
                                });
                            });


            services.AddMassTransit(cfg =>
            {
                cfg.AddConsumer<OrderTicketmessageConsumer>();
                cfg.AddBus(provider =>
                {
                    return Bus.Factory.CreateUsingRabbitMq(rmq =>
                    {
                        rmq.Host(new Uri("rabbitmq://rabbitmq"), "/", h =>
                        {
                            h.Username("guest");
                            h.Password("guest");
                        });
                        rmq.ReceiveEndpoint("EventBrite", e =>
                        {
                            e.ConfigureConsumer<OrderTicketmessageConsumer>(provider);

                        });
                    });

                });
            });

            services.AddMassTransitHostedService();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "EventAPI V1");
                });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
