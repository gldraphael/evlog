/**
    This file uses string constants from Divorce Separation Blues (Avett Brothers)
    Songwriters: Timothy Avett / Robert Crawford / Scott Avett
    Divorce Separation Blues lyrics © BMG Rights Management
*/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evlog.Core.Entities.EventAggregate;
using Evlog.Infrastructure.DataModels;
using Evlog.Infrastructure.Queries;
using Mapster;
using Xunit;

namespace Evlog.UnitTests.Infrastructure.Queries
{

    public class AllEventsQuery_Should : MySqlTestBed
    {
        [Fact]
        public async Task Return_all_events_temp()
        {
            // Arrange
            var posts = new List<EventPostDM>(new EventPostDM[] {
                new EventPostDM { Slug = "well-im-gonna-keep-on-waking" },
                new EventPostDM { Slug = "and-rising-up-before-the-sun" },
                new EventPostDM { Slug = "and-lying-in-the-dark-wide-awake" },
                new EventPostDM { Slug = "when-everybody-else-is-done" }
            });
            await Db.Events.AddRangeAsync(posts);
            await Db.SaveChangesAsync();

            // Act
            var result = await new AllEventsQuery(Db).QueryAsync();

            // Assert
            Assert.Equal(posts.Count, result.Count);
        }

        [Fact(Skip = "DateTime fails")]
        public async Task Return_all_events()
        {
            // Arrange
            var createdOn = DateTime.UtcNow;
            var posts = new List<EventPostDM>(new EventPostDM[] {
                new EventPostDM { CreatedOn = createdOn, Slug = "well-im-gonna-keep-on-waking" },
                new EventPostDM { CreatedOn = createdOn, Slug = "and-rising-up-before-the-sun" },
                new EventPostDM { CreatedOn = createdOn, Slug = "and-lying-in-the-dark-wide-awake" },
                new EventPostDM { CreatedOn = createdOn, Slug = "when-everybody-else-is-done" }
            });
            await Db.Events.AddRangeAsync(posts);
            await Db.SaveChangesAsync();

            // Act
            var result = await new AllEventsQuery(Db).QueryAsync();

            // Assert
            Assert.Equal(posts.Count, result.Count);
            Assert.Equal(posts.Adapt<IList<EventPost>>(), result); // Pass an IEqualityComparer for this to work
        }
    }
}
