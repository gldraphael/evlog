using Evlog.Infrastructure.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Evlog.Infrastructure.SeedStrategies
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
            if (await this.db.Events.AnyAsync())
            {
                logger.LogInformation("Not seeding the DB because it has data in the events table.");
                return;
            }

            var seedEvents = new[]
            {
                new EventPostDM
                {
                    Title = "XYZ 2019",
                    Description = "This is going to be fuuuunnnnn.",
                    Body = "",
                    CreatedOn = DateTime.UtcNow,
                    StartDateTime = DateTime.UtcNow + TimeSpan.FromDays(7),
                    EndDate = DateTime.UtcNow + TimeSpan.FromDays(7.5),
                    EndTime = DateTime.UtcNow + TimeSpan.FromDays(7.5),
                    Slug = "xyz-2019",
                    Announcements = new []
                    {
                        new AnnouncementDM
                        {
                            Text = "Reminder that the event is 16+ only.",
                            LongText = null,

                            CreatedOn = DateTime.Now,
                            LastEditedOn = DateTime.Now,
                        }
                    },
                    Registrations = new []
                    {
                        new RegistrationDM
                        {
                            Email = "janedoe@email.com"
                        },
                        new RegistrationDM
                        {
                            Email = "johndoe@email.com"
                        }
                    }
                }
            };

            await this.db.Events.AddRangeAsync(seedEvents);
            await this.db.SaveChangesAsync();
            logger.LogInformation("Seeded the database with default values.");
        }
    }
}
