using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evlog.Infrastructure.Data.DataModels;
using Evlog.Infrastructure.Data.Queries;
using Xunit;

namespace Evlog.UnitTests.Infrastructure.Queries
{
    public class PastEventsQuery_Should : MySqlTestBed
    {
        [Fact]
        public async Task Return_all_past_events()
        {
            // Arrange
            var oldDate = DateTime.Today.AddDays(-10).ToUniversalTime();
            var newDate = DateTime.Today.AddDays(10).ToUniversalTime();
            var posts = new List<EventPostDM>(new EventPostDM[] {
                new EventPostDM { StartTimeUtc = oldDate, Slug = "well-im-gonna-keep-on-waking", Title = "look" },
                new EventPostDM { StartTimeUtc = oldDate, Slug = "and-rising-up-before-the-sun", Title = "at" },
                new EventPostDM { StartTimeUtc = newDate, Slug = "and-lying-in-the-dark-wide-awake", Title = "me" },
                new EventPostDM { StartTimeUtc = newDate, Slug = "when-everybody-else-is-done", Title = "I'm not helpless" },
            });
            await Db.EventPosts.AddRangeAsync(posts);
            await Db.SaveChangesAsync();

            // Act
            var result = await new PastEventsQuery(Db).QueryAsync();

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task Return_empty_when_no_past_events_exist()
        {
            // Arrange
            var date = DateTime.Today.AddDays(10).ToUniversalTime();
            var posts = new List<EventPostDM>(new EventPostDM[] {
                new EventPostDM { StartTimeUtc = date, Slug = "well-im-gonna-keep-on-waking", Title = "look" },
                new EventPostDM { StartTimeUtc = date, Slug = "and-rising-up-before-the-sun", Title = "at" },
                new EventPostDM { StartTimeUtc = date, Slug = "and-lying-in-the-dark-wide-awake", Title = "me" },
                new EventPostDM { StartTimeUtc = date, Slug = "when-everybody-else-is-done", Title = "is'm not helpless" },
            });
            await Db.EventPosts.AddRangeAsync(posts);

            // Act
            var result = await new PastEventsQuery(Db).QueryAsync();

            // Assert
            Assert.Empty(result);
        }
    }
}
