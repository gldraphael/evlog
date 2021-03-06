using System.Diagnostics;
using System.Threading.Tasks;
using Evlog.Infrastructure.Data.DataModels;
using Evlog.Infrastructure.Data.Queries;
using Xunit;

namespace Evlog.UnitTests.Infrastructure.Queries
{
    public class EventQuery_Should : MySqlTestBed
    {
        [Fact]
        public async Task Return_the_correct_event_with_slug()
        {
            // Arrange
            const string slug = "hey-there";
            await Db.EventPosts.AddAsync(new EventPostDM {
                Title = "hey there",
                Slug = slug
            });
            await Db.SaveChangesAsync();
            var query = new EventQuery(Db);

            // Act
            var result = await query.QueryAsync(slug: slug);

            // Assert
            Debug.Assert(result != null);
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
