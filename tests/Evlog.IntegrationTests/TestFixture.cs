using System;
using System.Collections.Generic;
using System.Net.Http;
using Evlog.Infrastructure;
using Evlog.Infrastructure.DataModels;
using Evlog.Web;
using Mapster;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Evlog.IntegrationTests
{
    // A test fixture which hosts the target project in an in-memory server.
    public class TestFixture : IDisposable
    {
        private readonly TestServer _server;
        public HttpClient Client { get; }
        public IServiceProvider Services => _server.Host.Services;

		public TestFixture()
        {
			var builder = new WebHostBuilder()
				.UseContentRoot("../../../../../src/Evlog.Web")
				.UseEnvironment("Development")
				.ConfigureAppConfiguration(app =>
                {
                    app.AddJsonFile("appsettings.json");
                })
				.UseStartup<Startup>()
				.ConfigureServices(ConfigureServices);

			_server = new TestServer(builder);

            using (var serviceScope = _server.Host.Services
                        .GetRequiredService<IServiceScopeFactory>()
                        .CreateScope())
			{
                var db = serviceScope.ServiceProvider.GetRequiredService<MongoDbContext>();
                db.Events.InsertMany(SeedData.Events.Adapt<IEnumerable<EventPostDM>>());
			}

			Client = _server.CreateClient();
			Client.BaseAddress = _server.BaseAddress;
        }


        public void Dispose()
        {
            Client.Dispose();
            _server.Dispose();
        }

		protected virtual void ConfigureServices(IServiceCollection services)
        {
            // services.get
        }

    }
}
