using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Evlog.IntegrationTests.Pages
{
    public class IndexPage_Should : IClassFixture<TestFixture>
	{
        private readonly TestFixture _fixture;

		public IndexPage_Should(TestFixture fixture)
		{
            _fixture = fixture;
		}

		[Fact]
		public async Task Request_ReturnsOK()
		{
            using(var client = _fixture.CreateClient())
            {
                // Act
                var response = await client.GetAsync("/");

                // Assert
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
		}
	}
}