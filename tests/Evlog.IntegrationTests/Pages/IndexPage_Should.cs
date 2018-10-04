using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Evlog.IntegrationTests.Pages
{
    public class IndexPage_Should : IClassFixture<TestFixture>
	{
		private readonly HttpClient _client;

		public IndexPage_Should(TestFixture factory)
		{
			_client = factory.Client;
		}

		[Fact]
		public async Task Request_ReturnsOK()
		{
			// Act
			var response = await _client.GetAsync("/");

			// Assert
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		}
	}
}