using System.Collections.Generic;
using System.IO;
using Evlog.Infrastructure;
using Evlog.Infrastructure.DataModels;
using Evlog.Web;
using Evlog.Web.Extensions;
using Mapster;
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

               // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                    .AddMongo(configuration)
                    .BuildServiceProvider();
                services.AddMongo(configuration);

                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                {
                    var serviceScope = scope.ServiceProvider;
                    var db = serviceScope.GetRequiredService<MongoDbContext>();
                    db.Database.Client.DropDatabase(db.Database.DatabaseNamespace.DatabaseName);
                    db.Events.InsertMany(SeedData.Events.Adapt<IEnumerable<EventPostDM>>());
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
