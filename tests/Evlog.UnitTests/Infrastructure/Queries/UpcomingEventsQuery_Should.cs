using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evlog.Infrastructure.Data.DataModels;
using Evlog.Infrastructure.Data.Queries;
using Xunit;

namespace Evlog.UnitTests.Infrastructure.Queries
{
    public class UpcomingEventsQuery_Should : MySqlTestBed
    {
        [Fact]
        public async Task Return_all_past_events()
        {
            // Arrange
            var oldDate = DateTime.Today.AddDays(-10).ToUniversalTime();
            var newDate = DateTime.Today.AddDays(10).ToUniversalTime();
            var posts = new List<EventPostDM>(new EventPostDM[] {
                new EventPostDM { CreatedOn = oldDate, StartTimeUtc = oldDate, Slug = "well-im-gonna-keep-on-waking" },
                new EventPostDM { CreatedOn = oldDate, StartTimeUtc = oldDate, Slug = "and-rising-up-before-the-sun" },
                new EventPostDM { CreatedOn = newDate, StartTimeUtc = newDate, Slug = "and-lying-in-the-dark-wide-awake" },
                new EventPostDM { CreatedOn = newDate, StartTimeUtc = newDate, Slug = "when-everybody-else-is-done" }
            });
            await Db.EventPosts.AddRangeAsync(posts);
            await Db.SaveChangesAsync();

            // Act
            var result = await new UpcomingEventsQuery(Db).QueryAsync();

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task Return_empty_when_no_past_events_exist()
        {
            // Arrange
            var date = DateTime.Today.AddDays(-10).ToUniversalTime();
            var posts = new List<EventPostDM>(new EventPostDM[] {
                new EventPostDM { CreatedOn = date, StartTimeUtc = date, Slug = "well-im-gonna-keep-on-waking" },
                new EventPostDM { CreatedOn = date, StartTimeUtc = date, Slug = "and-rising-up-before-the-sun" },
                new EventPostDM { CreatedOn = date, StartTimeUtc = date, Slug = "and-lying-in-the-dark-wide-awake" },
                new EventPostDM { CreatedOn = date, StartTimeUtc = date, Slug = "when-everybody-else-is-done" }
            });
            await Db.EventPosts.AddRangeAsync(posts);
            await Db.SaveChangesAsync();

            // Act
            var result = await new UpcomingEventsQuery(Db).QueryAsync();

            // Assert
            Assert.Empty(result);
        }
    }
}