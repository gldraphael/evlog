using System;
using System.Net.Http;
using Evlog.Web;

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
            
        }

    }
}
