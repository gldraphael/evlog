using System;
using System.Net.Http;
using Xunit;

namespace Evlog.IntegrationTests
{
    public class TestFixture : IDisposable
    {
        private readonly EvlogTestAppFactory _factory;
        public HttpClient Client { get; }
        public IServiceProvider Services => _factory.Server.Host.Services;

		public TestFixture()
        {
            _factory = new EvlogTestAppFactory();
            Client = _factory.CreateClient();
        }

        public void Dispose()
        {
            Client.Dispose();
            _factory.Dispose();
        }
    }
}
