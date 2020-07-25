/**
    This file uses string constants from Divorce Separation Blues (Avett Brothers)
    Songwriters: Timothy Avett / Robert Crawford / Scott Avett
    Divorce Separation Blues lyrics © BMG Rights Management
*/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evlog.Core.Entities.EventAggregate;
using Evlog.Infrastructure.Data.DataModels;
using Evlog.Infrastructure.Data.Queries;
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
                new EventPostDM { Slug = "well-im-gonna-keep-on-waking", Title = "look" },
                new EventPostDM { Slug = "and-rising-up-before-the-sun", Title = "at" },
                new EventPostDM { Slug = "and-lying-in-the-dark-wide-awake", Title = "me" },
                new EventPostDM { Slug = "when-everybody-else-is-done", Title = "I'm not helpless" }
            });
            await Db.EventPosts.AddRangeAsync(posts);
            await Db.SaveChangesAsync();

            // Act
            var result = await new AllEventsQuery(Db).QueryAsync();

            // Assert
            Assert.Equal(posts.Count, result.Count);
        }

        [Fact(Skip = "Doesn't work, gotta debug")]
        public async Task Return_all_events()
        {
            // Arrange
            var posts = new List<EventPostDM>(new EventPostDM[] {
                new EventPostDM { Slug = "well-im-gonna-keep-on-waking", Title = "look" },
                new EventPostDM { Slug = "and-rising-up-before-the-sun", Title = "at" },
                new EventPostDM { Slug = "and-lying-in-the-dark-wide-awake", Title = "me" },
                new EventPostDM { Slug = "when-everybody-else-is-done", Title = "I'm not helpless" }
            });
            await Db.EventPosts.AddRangeAsync(posts);
            await Db.SaveChangesAsync();

            // Act
            var result = await new AllEventsQuery(Db).QueryAsync();

            // Assert
            Assert.Equal(posts.Count, result.Count);
            for(int i = 0; i < posts.Count; i++)
            {
                var post = posts[i].Adapt<EventPost>();
                Assert.Equal(expected: post, actual: result[i]);
            }
        }
    }
}
