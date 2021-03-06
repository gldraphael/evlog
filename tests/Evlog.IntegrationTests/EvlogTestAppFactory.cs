using System.IO;
using Evlog.Infrastructure;
using Evlog.Infrastructure.Data;
using Evlog.Web;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evlog.IntegrationTests
{
   public sealed class EvlogTestAppFactory : WebApplicationFactory<Startup>
   {
       protected override IWebHostBuilder CreateWebHostBuilder()
       {
           var builder = WebHost.CreateDefaultBuilder()
               .UseContentRoot(Directory.GetCurrentDirectory())
               .UseConfiguration(GetIConfigurationRoot())
               .ConfigureAppConfiguration(c =>
               {
                   c.AddEnvironmentVariables();
               })
               .UseStartup<TestStartup>();

           return builder;
       }

       protected override TestServer CreateServer(IWebHostBuilder builder)
       {
           var server = base.CreateServer(builder);
           var sp = server.Host.Services;
           using (var scope = sp.CreateScope())
           {
               var scopedServices = scope.ServiceProvider;

               var db = scopedServices.GetRequiredService<AppDbContext>();
               db.Database.EnsureCreated();
               db.EventPosts.AddRange(SeedData.Events);
               db.SaveChanges();
           }
           return server;
       }

        private static IConfigurationRoot GetIConfigurationRoot() =>
            new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .AddEnvironmentVariables()
                .Build();
    }
}
