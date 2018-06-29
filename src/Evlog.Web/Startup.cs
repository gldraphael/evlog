using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evlog.Domain;
using Evlog.Domain.Queries;
using Evlog.Infrastructure;
using Evlog.Infrastructure.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Evlog.Web
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
            services.AddRouting(options => options.LowercaseUrls = true)
                    .AddMvc()
                    .AddRazorPagesOptions(options => {
                        options.Conventions.AddPageRoute("/Events/View", "{slug}");
                    });

            var appsettings = Configuration.GetSection("AppSettings").Get<AppSettings>();
            if(appsettings.UseMongo)
            {
                var configSection = Configuration.GetSection("Mongo");
                var config = configSection.Get<MongoConfig>();
                var mongoClient = new MongoClient(connectionString: config.ConnectionString) as IMongoClient;
                var database = mongoClient.GetDatabase(config.Database);
                var eventsCollection = database.GetCollection<EventPost>("Events");

                services.Configure<MongoConfig>(configSection);
                services.AddSingleton(mongoClient);
                services.AddSingleton(database);
                services.AddSingleton(eventsCollection);
            }

            services.AddTransient<IAllEventsQuery, AllEventsQuery>();
            services.AddTransient<IPastEventsQuery, PastEventsQuery>();
            services.AddTransient<IUpcomingEventsQuery, UpcomingEventsQuery>();
            services.AddTransient<IEventQuery, EventQuery>();
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
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
