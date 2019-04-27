using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Evlog.IntegrationTests.Pages
{
    public class PublicPages_that_should : IClassFixture<EvlogTestAppFactory>
    {
        private readonly HttpClient _client;

        public PublicPages_that_should(EvlogTestAppFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/events/xyz-is-happening-again")]
		public async Task Return_OK(string route)
		{
			// Act
			var response = await _client.GetAsync(route);

			// Assert
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		}
    }
}
