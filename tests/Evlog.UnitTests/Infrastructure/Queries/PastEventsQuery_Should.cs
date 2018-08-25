using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evlog.Domain.EventAggregate;
using Evlog.Infrastructure.DataModels;
using Evlog.Infrastructure.Queries;
using Mapster;
using Moq;
using Xunit;

namespace Evlog.UnitTests.Infrastructure.Queries
{
    public class PastEventsQuery_Should : MongoTestBed
    {
        [Fact]
        public async Task Return_all_past_events()
        {
            // Arrange
            var oldDate = DateTime.Today.AddDays(-10).ToUniversalTime();
            var newDate = DateTime.Today.AddDays(10).ToUniversalTime();
            var posts = new List<EventPostDM>(new EventPostDM[] {
                new EventPostDM { CreatedOn = oldDate, StartDateTime = oldDate, Slug = "well-im-gonna-keep-on-waking" },
                new EventPostDM { CreatedOn = oldDate, StartDateTime = oldDate, Slug = "and-rising-up-before-the-sun" },
                new EventPostDM { CreatedOn = newDate, StartDateTime = newDate, Slug = "and-lying-in-the-dark-wide-awake" },
                new EventPostDM { CreatedOn = newDate, StartDateTime = newDate, Slug = "when-everybody-else-is-done" }
            });
            await Db.Events.InsertManyAsync(posts);

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
                new EventPostDM { CreatedOn = date, StartDateTime = date, Slug = "well-im-gonna-keep-on-waking" },
                new EventPostDM { CreatedOn = date, StartDateTime = date, Slug = "and-rising-up-before-the-sun" },
                new EventPostDM { CreatedOn = date, StartDateTime = date, Slug = "and-lying-in-the-dark-wide-awake" },
                new EventPostDM { CreatedOn = date, StartDateTime = date, Slug = "when-everybody-else-is-done" }
            });
            await Db.Events.InsertManyAsync(posts);

            // Act
            var result = await new PastEventsQuery(Db).QueryAsync();

            // Assert
            Assert.Empty(result);
        }
    }
}
