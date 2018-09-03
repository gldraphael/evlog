using System.Collections.Generic;
using System.IO;
using Evlog.Infrastructure;
using Evlog.Infrastructure.DataModels;
using Evlog.Web;
using Evlog.Web.Extensions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evlog.IntegrationTests
{
   public class EvlogTestAppFactory : WebApplicationFactory<Startup>
   {
       protected override void ConfigureWebHost(IWebHostBuilder builder)
       {
            builder.ConfigureServices(services =>
            {
                var configuration = GetIConfigurationRoot();
                services.AddMongo(configuration);

                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<MongoDbContext>();
                    db.Database.Client.DropDatabase(db.Database.DatabaseNamespace.DatabaseName);
                    db.Events.InsertMany(SeedData.Events);
                }
            });
        }

        protected override IWebHostBuilder CreateWebHostBuilder() =>
            new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseEnvironment("Development")
                .UseConfiguration(GetIConfigurationRoot())
                .UseStartup<Startup>();

        public static IConfigurationRoot GetIConfigurationRoot() =>
            new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .AddEnvironmentVariables()
                .Build();
   }
}
