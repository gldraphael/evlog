using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Evlog.IntegrationTests.Pages.Events
{
    public class ViewPage_should : IClassFixture<TestFixture>
    {
        private readonly HttpClient _client;

		public ViewPage_should(TestFixture factory)
		{
            _client = factory.Client;
		}

		[Fact]
		public async Task Return_OK()
		{
			// Act
			var response = await _client.GetAsync("/events/xyz-is-happening-again");

			// Assert
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		}
    }
}
