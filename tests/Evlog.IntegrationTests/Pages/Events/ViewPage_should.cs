using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Evlog.IntegrationTests.Pages.Events
{
    public class ViewPage_should : IClassFixture<TestFixture>
    {
        private readonly TestFixture _fixture;

		public ViewPage_should(TestFixture fixture)
		{
            _fixture = fixture;
		}

		[Fact]
		public async Task Return_OK()
		{
            using(var client = _fixture.CreateClient())
            {
                // Act
                var response = await client.GetAsync("/events/xyz-is-happening-again");

                // Assert
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
		}
    }
}
