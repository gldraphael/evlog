using System;
using System.Net.Http;
using Xunit;

namespace Evlog.IntegrationTests
{
    public class TestFixture : IDisposable
    {
        private readonly EvlogTestAppFactory _factory;
        public IServiceProvider Services => _factory.Server.Host.Services;

		public TestFixture()
        {
            _factory = new EvlogTestAppFactory();
        }

        public HttpClient CreateClient() => _factory.CreateClient();

        public void Dispose()
        {
            _factory.Dispose();
        }
    }
}
