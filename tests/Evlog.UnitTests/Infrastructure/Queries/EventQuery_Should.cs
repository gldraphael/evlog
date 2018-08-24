using System.Threading.Tasks;
using Evlog.Infrastructure.DataModels;
using Evlog.Infrastructure.Queries;
using Xunit;

namespace Evlog.UnitTests.Infrastructure.Queries
{
    public class EventQuery_Should : MongoTestBed
    {
        [Fact]
        public async Task Return_the_correct_event_with_slug()
        {
            // Arrange
            const string slug = "hey-there";
            Db.Events.InsertOne(new EventPostDM {
                Slug = slug
            });
            var query = new EventQuery(Db);

            // Act
            var result = await query.QueryAsync(slug: slug);

            // Assert
            Assert.Equal(slug, result.Slug);
        }

        [Fact]
        public async Task Return_null_when_event_doesnt_exist()
        {
            // Arrange
            const string slug = "hey-there";
            var query = new EventQuery(Db);

            // Act
            var result = await query.QueryAsync(slug: slug);

            // Assert
            Assert.Null(result);
        }
    }
}
