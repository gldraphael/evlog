using System.IO;
using Evlog.Infrastructure;
using Evlog.Web;
using Evlog.Web.Extensions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evlog.IntegrationTests
{
   public class EvlogTestAppFactory : WebApplicationFactory<Startup>
   {
        private MongoDbContext db;

       protected override void ConfigureWebHost(IWebHostBuilder builder)
       {
            builder.ConfigureServices(services =>
            {
                var configuration = GetIConfigurationRoot();
                services.AddMongo(configuration);

                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                {
                    db = scope.ServiceProvider.GetRequiredService<MongoDbContext>();
                    seedDbIfNotSeeded(db);
                }
            });
       }

        protected override IWebHostBuilder CreateWebHostBuilder() =>
            new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseEnvironment("Development")
                .UseConfiguration(GetIConfigurationRoot())
                .UseStartup<TestStartup>();

        public static IConfigurationRoot GetIConfigurationRoot() =>
            new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .AddEnvironmentVariables()
                .Build();

        protected override void Dispose(bool disposing)
        {
            if(disposing && db != null)
            {
                db.Database.Client.DropDatabase(db.Database.DatabaseNamespace.DatabaseName);
            }
            base.Dispose(disposing);
        }


        private static bool isDbSeeded = false;
        private static object lockForIsdbSeed = new object();
        private static void seedDbIfNotSeeded(MongoDbContext db)
        {
            lock (lockForIsdbSeed)
            {
                if (!isDbSeeded)
                {
                    db.Events.InsertMany(SeedData.Events);
                    isDbSeeded = true;
                }
            }
        }
    }
}
