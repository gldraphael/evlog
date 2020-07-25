using Evlog.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Evlog.Infrastructure.Data.SeedStrategies
{
    class DevSeedStrategy : ISeedStrategy
    {
        private readonly AppDbContext db;
        private readonly ILogger<DevSeedStrategy> logger;
        public DevSeedStrategy(AppDbContext db, ILogger<DevSeedStrategy> logger)
        {
            this.db = db;
            this.logger = logger;
        }

        public async Task SeedAsync()
        {
            // Don't seed if there's any data in the events table
            if (await this.db.EventPosts.AnyAsync())
            {
                logger.LogInformation("Not seeding the DB because it has data in the events table.");
                return;
            }

            var seedEvents = new[]
            {
                new EventPostDM
                {
                    Title = "XYZ 2020",
                    Description = "This is going to be fuuuunnnnn.",
                    Body = null,
                    StartTimeUtc = DateTime.UtcNow + TimeSpan.FromDays(7),
                    EndTimeUtc = DateTime.UtcNow + TimeSpan.FromDays(7.5),
                    Slug = "xyz-2019",
                    Registrations = new []
                    {
                        new RegistrationDM
                        {
                            Name = "Jane Doe",
                            Email = "janedoe@email.com"
                        },
                        new RegistrationDM
                        {
                            Name = "John Doe",
                            Email = "johndoe@email.com"
                        }
                    }
                }
            };

            await this.db.EventPosts.AddRangeAsync(seedEvents);
            await this.db.SaveChangesAsync();
            logger.LogInformation("Seeded the database with default values.");
        }
    }
}
