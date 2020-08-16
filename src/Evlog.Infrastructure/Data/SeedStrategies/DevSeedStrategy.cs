using Evlog.Core.Abstractions.Repositories;
using Evlog.Core.Entities.EventAggregate;
using Evlog.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Evlog.Infrastructure.Data.SeedStrategies
{
    // Seed data taken from: https://azure.microsoft.com/en-in/community/events/
    class DevSeedStrategy : ISeedStrategy
    {

        const string DEFAULT_USER = "admin@example.com";
        const string DEFAULT_PASS = "theadmin'spassword";


        private readonly AppDbContext db;
        private readonly UserManager<EvlogWebUserDM> userManager;
        private readonly ILogger<DevSeedStrategy> logger;
        private readonly IEventPostRepository events;

        public DevSeedStrategy(
            AppDbContext db,
            UserManager<EvlogWebUserDM> userManager,
            ILogger<DevSeedStrategy> logger,
            IEventPostRepository events)
        {
            this.db = db;
            this.userManager = userManager;
            this.logger = logger;
            this.events = events;
        }

        public async Task SeedAsync()
        {
            // Don't seed if there's any data in the events table
            if (await this.db.EventPosts.AnyAsync())
            {
                logger.LogInformation("Not seeding the DB because it has data in the events table.");
                return;
            }

            if(!await userManager.Users.AnyAsync())
            {
                await userManager.CreateAsync(
                    new EvlogWebUserDM
                    {
                        UserName = DEFAULT_USER,
                        EmailConfirmed = true
                    }, DEFAULT_PASS);
            }

            var seedEvents = new[]
            {
                new EventPost
                {
                    Title = "Building an Innovation Culture to enable the success of your Digital Transformation",
                    Description = "Lee Hickin and Veli-Matti will discuss how Australian businesses are building an innovation culture to enable the success of their digital transformation journeys.",
                    BodyMarkdown = "Businesses across all industries are talking about digital transformation. However, we need to be mindful that this transformation isn't just about the technology – it’s also about the people and the culture of an organisation that will enable this transformation to deliver value for your customers.   \n\nLee Hickin and Veli-Matti will discuss how Australian businesses are building an innovation culture to enable the success of their digital transformation journeys.   \n\nIn this free webinar, you'll learn about:   \n\n* The four pillars of transformation - vision & strategy, culture, unique potential and capabilities.\n* Creating a culture to increase your data maturity and deliver return on your transformation investments.\n* The rise of the citizen data scientist and the democratisation of AI",
                    StartTimeUtc = new DateTimeOffset(year: 2020, month: 8, day: 4, hour: 11, minute:  0, second: 0, offset: TimeSpan.FromHours(10)).UtcDateTime,
                    EndTimeUtc   = new DateTimeOffset(year: 2020, month: 8, day: 4, hour: 11, minute: 50, second: 0, offset: TimeSpan.FromHours(10)).UtcDateTime,
                    Slug = "building-an-innovation-culture-to-enable-the-success-of-your-digital-transformation"
                },

                new EventPost
                {
                    Title = "Get Kubernetes Up and Running",
                    Description = "Join this free webinar to learn how to get started with Kubernetes open-source container orchestration software and get a sneak peek of the second edition of Kubernetes from co-founder Brendan Burns.",
                    BodyMarkdown = "Join this free webinar to learn how to get started with Kubernetes open-source container orchestration software and get a sneak peek of the second edition of Kubernetes from co-founder Brendan Burns.   \n\nYou’ll also learn about: \n* Answers to frequently asked questions such as “What should I put in a pod?”\n* Using different Kubernetes objects in tandem to achieve reliable software rollout. \n* Using a managed Kubernetes service to simplify day-to-day operations such as upgrading, patching, and scaling.",
                    StartTimeUtc = new DateTimeOffset(year: 2020, month: 8, day: 13, hour: 11, minute: 0, second: 0, offset: TimeSpan.FromHours(10)).UtcDateTime,
                    EndTimeUtc   = new DateTimeOffset(year: 2020, month: 8, day: 13, hour: 12, minute: 0, second: 0, offset: TimeSpan.FromHours(10)).UtcDateTime,
                    Slug = "get-kubernetes-up-and-running"
                },
                new EventPost
                 {
                    Title = "Azure App Services",
                    Slug = "azure-app-services",
                    BodyMarkdown = "Quickly create powerful cloud apps using a fully-managed platform. Quickly build, deploy and scale enterprise-grade web, mobile and API apps running on any platform A one hour webinar on Azure App Services.",
                    StartTimeUtc = new DateTime(2018, 04, 30, 15, 00, 00)
                  },
                new EventPost
                  {
                    Title = "High performance computing",
                    Slug = "high-performance-computing",
                    BodyMarkdown = "Tap into unlimited resources to scale your high performance computing (HPC) jobs—analysing large-scale data, running simulations and financial models and experimenting while reducing time to market.",
                    StartTimeUtc = new DateTime(1983, 05, 01, 15, 00, 00)
                  },
                new EventPost
                  {
                    Title = "Network Monitoring with Network Performance Monitor (NPM)",
                    Slug = "network-monitoring-with-network-performance-monitor-npm",
                    BodyMarkdown = "A one hour session introduction and QnA Network Monitoring with Network Performance Monitor (NPM).",
                    StartTimeUtc = new DateTime(2018, 05, 08, 12, 00, 00)
                  },
                new EventPost
                  {
                    Title = "Learn Machine Learning using Azure ML",
                    Slug = "learn-machine-learning-using-azure-ml",
                    BodyMarkdown = "Machine learning is current buzz word in our industry and everyone wants to know what it is. Machine learning is in our industry for very long from the ages of Alan Turing. But it has gained momentum and mostly possible due to the cloud compute power that is available now. With Azure ML we can do wonders with data. Implementing any machine learning algorithm is bunch of drag and drops that you need to in Azure ML Studio. \n\nIn this webinar you will be learning what machine learning is and how to choose an algorithm for your problem. Five questions to ask on choosing ML algorithm. Below are the agenda for our webinar: \n\nArtificial Intelligence Vs Machine learning Vs Deep learning \nWhat is Naive Bayes? \nWhat is feature and label? \nDifference between R and Python?",
                    StartTimeUtc = new DateTime(2019, 05, 15, 12, 00, 00)
                  },
                new EventPost
                  {
                    Title = "Webinar: Azure DevOps and Containers",
                    Slug = "webinar-azure-devops-and-containers",
                    BodyMarkdown = "It's time to modernize and future proof your applications. Learn how new constructs such as PaaS, web and mobile app services, Serverless, microservices, containers and others can do this while ensuring continuous innovation through end to end DevOps.",
                    StartTimeUtc = new DateTime(2019, 05, 17, 07, 30, 00)
                  },
                new EventPost
                  {
                    Title = "Building Modern Websites using Microsoft Azure",
                    Slug = "building-modern-websites-using-microsoft-azure",
                    BodyMarkdown = "Learn how to quickly build modern, secure, scalable and highly available websites using the powerful web infrastructure provided by Microsoft Azure. Organisations across the planet are seeing great success deploying their websites on top of the Azure platform. See how you can join them using the new Azure Digital Marketing Solution sample implementations. In this session, learn how: - Understand the key services in Azure that will help you create great web experience - See how other companies are building successful web experiences with Azure - Learn how to get started creating your own modern website using the new Azure Sample Implementation.",
                    StartTimeUtc = new DateTime(2017, 08, 16, 02, 00, 00)
                  }
            };

            foreach (var eventPost in seedEvents)
            {
                eventPost.RenderMarkdown();
                await events.AddAsync(eventPost);
            }

            logger.LogInformation("Database successfully seeded using the DevSeedStrategy.");
        }
    }
}
