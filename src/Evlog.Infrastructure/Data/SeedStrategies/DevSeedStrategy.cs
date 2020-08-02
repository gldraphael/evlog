using Evlog.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Evlog.Infrastructure.Data.SeedStrategies
{
    // Seed data taken from: https://azure.microsoft.com/en-in/community/events/
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
                    Title = "Building an Innovation Culture to enable the success of your Digital Transformation",
                    Description = "Lee Hickin and Veli-Matti will discuss how Australian businesses are building an innovation culture to enable the success of their digital transformation journeys.",
                    BodyMarkdown = "Businesses across all industries are talking about digital transformation. However, we need to be mindful that this transformation isn't just about the technology – it’s also about the people and the culture of an organisation that will enable this transformation to deliver value for your customers.   \n\nLee Hickin and Veli-Matti will discuss how Australian businesses are building an innovation culture to enable the success of their digital transformation journeys.   \n\nIn this free webinar, you'll learn about:   \n\n* The four pillars of transformation - vision & strategy, culture, unique potential and capabilities.\n* Creating a culture to increase your data maturity and deliver return on your transformation investments.\n* The rise of the citizen data scientist and the democratisation of AI",
                    StartTimeUtc = new DateTimeOffset(year: 2020, month: 8, day: 4, hour: 11, minute:  0, second: 0, offset: TimeSpan.FromHours(10)).UtcDateTime,
                    EndTimeUtc   = new DateTimeOffset(year: 2020, month: 8, day: 4, hour: 11, minute: 50, second: 0, offset: TimeSpan.FromHours(10)).UtcDateTime,
                    Slug = "building-an-innovation-culture-to-enable-the-success-of-your-digital-transformation",
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
                },

                new EventPostDM
                {
                    Title = "Get Kubernetes Up and Running",
                    Description = "Join this free webinar to learn how to get started with Kubernetes open-source container orchestration software and get a sneak peek of the second edition of Kubernetes from co-founder Brendan Burns.",
                    BodyMarkdown = "Join this free webinar to learn how to get started with Kubernetes open-source container orchestration software and get a sneak peek of the second edition of Kubernetes from co-founder Brendan Burns.   \n\nYou’ll also learn about: \n* Answers to frequently asked questions such as “What should I put in a pod?”\n* Using different Kubernetes objects in tandem to achieve reliable software rollout. \n* Using a managed Kubernetes service to simplify day-to-day operations such as upgrading, patching, and scaling.",
                    StartTimeUtc = new DateTimeOffset(year: 2020, month: 8, day: 13, hour: 11, minute: 0, second: 0, offset: TimeSpan.FromHours(10)).UtcDateTime,
                    EndTimeUtc   = new DateTimeOffset(year: 2020, month: 8, day: 13, hour: 12, minute: 0, second: 0, offset: TimeSpan.FromHours(10)).UtcDateTime,
                    Slug = "get-kubernetes-up-and-running",
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
                },
            };

            await this.db.EventPosts.AddRangeAsync(seedEvents);
            await this.db.SaveChangesAsync();
            logger.LogInformation("Seeded the database with default values.");
        }
    }
}
