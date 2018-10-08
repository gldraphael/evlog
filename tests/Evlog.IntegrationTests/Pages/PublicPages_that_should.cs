using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Evlog.IntegrationTests.Pages
{
    public class PublicPages_that_should : IClassFixture<TestFixture>
    {
        private readonly TestFixture _fixture;

        public PublicPages_that_should(TestFixture fixture)
		{
            _fixture = fixture;
		}

        [Theory]
        [InlineData("/")]
        [InlineData("/events/xyz-is-happening-again")]
		public async Task Return_OK(string route)
		{
            using(var client = _fixture.CreateClient())
            {
                // Act
                var response = await client.GetAsync(route);

                // Assert
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
		}
    }
}
