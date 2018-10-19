using Evlog.Infrastructure;
using Evlog.Infrastructure.DataModels;
using Evlog.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Evlog.IntegrationTests
{
    public class TestStartup : Startup
    {
        private static bool isInitialized = false;
        private static object lockForIsInitialized = new object();
        private static IConfigurationSection mongoConfigSection;
        private static MongoConfig mongoConfig;
        private static IMongoClient mongoClient;
        private static IMongoDatabase mongoDatabase;
        private static IMongoCollection<UserDM> usersCollection;
        private static IMongoCollection<EventPostDM> eventsCollection;

        public TestStartup(IConfiguration config) : base(config)
        {
            lock(lockForIsInitialized)
            {
                if (!isInitialized)
                {
                    var appsettings = config.GetSection("AppSettings").Get<AppSettings>();
                    if (appsettings.UseMongo)
                    {
                        mongoConfigSection = config.GetSection("Mongo");
                        mongoConfig = mongoConfigSection.Get<MongoConfig>();
                        mongoClient = new MongoClient(connectionString: mongoConfig.ConnectionString) as IMongoClient;
                        mongoDatabase = mongoClient.GetDatabase(mongoConfig.Database);
                        eventsCollection = mongoDatabase.GetCollection<EventPostDM>("Events");
                        usersCollection = mongoDatabase.GetCollection<UserDM>("Users");
                    }
                    isInitialized = true;
                }
            }
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddSingleton(mongoClient);
            services.AddSingleton(mongoDatabase);
            services.AddSingleton(eventsCollection);
            services.AddSingleton(usersCollection);
        }

    }
}
