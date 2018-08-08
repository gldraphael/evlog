using Evlog.Domain.Queries;
using Evlog.Infrastructure;
using Evlog.Infrastructure.DataModels;
using Evlog.Infrastructure.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Evlog.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEvlogQueries(this IServiceCollection services)
        {
            services.AddTransient<IAllEventsQuery, AllEventsQuery>();
            services.AddTransient<IPastEventsQuery, PastEventsQuery>();
            services.AddTransient<IUpcomingEventsQuery, UpcomingEventsQuery>();
            services.AddTransient<IEventQuery, EventQuery>();
        }


        public static void AddMongo(this IServiceCollection services, IConfiguration config)
        {
            var appsettings = config.GetSection("AppSettings").Get<AppSettings>();
            if(appsettings.UseMongo)
            {
                var configSection = config.GetSection("Mongo");
                var mongoConfig = configSection.Get<MongoConfig>();
                var mongoClient = new MongoClient(connectionString: mongoConfig.ConnectionString) as IMongoClient;
                var database = mongoClient.GetDatabase(mongoConfig.Database);
                var eventsCollection = database.GetCollection<EventPostDM>("Events");

                services.Configure<MongoConfig>(configSection);
                services.AddSingleton(mongoClient);
                services.AddSingleton(database);
                services.AddSingleton(eventsCollection);
            }
        }

        public static void AddEvlogMvc(this IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true)
                    .AddMvc()
                    .AddRazorPagesOptions(options => {
                        options.Conventions.AddPageRoute("/Events/View", "events/{slug}");
                    });
        }

    }
}