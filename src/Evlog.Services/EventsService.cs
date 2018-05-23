using System;
using System.Collections.Generic;
using System.Linq;
using Evlog.Domain;

namespace Evlog.Services
{
    public class EventsService : IEventsService
    {
        public List<EventPost> Get()
        {
            return dataset.ToList();
        }

        public EventPost Get(int id)
        {
            return dataset.SingleOrDefault(e => e.Id == id);
        }

        public EventPost Get(string slug)
        {
            return dataset.SingleOrDefault(e => e.Slug == slug);
        }

        public List<EventPost> GetUpcomingEvents()
        {
            return dataset.Where(e => e.StartDateTime > DateTime.UtcNow)
                .ToList();
        }

        public List<EventPost> GetPastEvents()
        {
            return dataset.Where(e => e.StartDateTime < DateTime.UtcNow)
                .ToList();
        }

        private readonly EventPost[] dataset = new EventPost[]{
            new EventPost
            {
                Id = 1,
                Title = "Azure App Services",
                Slug = "azure-app-services",
                Body = "Quickly create powerful cloud apps using a fully-managed platform. Quickly build, deploy and scale enterprise-grade web, mobile and API apps running on any platform A one hour webinar on Azure App Services.",
                StartDateTime = new DateTime(2018, 4, 30, 15, 0, 0)
            },
            new EventPost
            {
                Id = 2,
                Title = "High performance computing",
                Slug = "high-performance-computing",
                Body = "Tap into unlimited resources to scale your high performance computing (HPC) jobs—analysing large-scale data, running simulations and financial models and experimenting while reducing time to market.",
                StartDateTime = new DateTime(1983, 5, 1, 15, 0, 0)
            },
            new EventPost
            {
                Id = 3,
                Title = "Network Monitoring with Network Performance Monitor (NPM)",
                Slug = "network-monitoring-with-network-performance-monitor-npm",
                Body = "A one hour session introduction and QnA Network Monitoring with Network Performance Monitor (NPM).",
                StartDateTime = new DateTime(2018, 5, 8, 12, 0, 0)
            },
            new EventPost
            {
                Id = 4,
                Title = "Learn Machine Learning using Azure ML",
                Slug = "learn-machine-learning-using-azure-ml",
                Body = "Machine learning is current buzz word in our industry and everyone wants to know what it is. Machine learning is in our industry for very long from the ages of Alan Turing. But it has gained momentum and mostly possible due to the cloud compute power that is available now. With Azure ML we can do wonders with data. Implementing any machine learning algorithm is bunch of drag and drops that you need to in Azure ML Studio. \n\nIn this webinar you will be learning what machine learning is and how to choose an algorithm for your problem. Five questions to ask on choosing ML algorithm. Below are the agenda for our webinar: \n\nArtificial Intelligence Vs Machine learning Vs Deep learning \nWhat is Naive Bayes? \nWhat is feature and label? \nDifference between R and Python?",
                StartDateTime = new DateTime(2019, 5, 15, 12, 0, 0)
            },
            new EventPost
            {
                Id = 5,
                Title = "Webinar: Azure DevOps and Containers",
                Slug = "webinar-azure-devops-and-containers",
                Body = "It's time to modernize and future proof your applications. Learn how new constructs such as PaaS, web and mobile app services, Serverless, microservices, containers and others can do this while ensuring continuous innovation through end to end DevOps.",
                StartDateTime = new DateTime(2019, 5, 17, 7, 30, 0)
            },
            new EventPost
            {
                Id = 6,
                Title = "Building Modern Websites using Microsoft Azure",
                Slug = "building-modern-websites-using-microsoft-azure",
                Body = "Learn how to quickly build modern, secure, scalable and highly available websites using the powerful web infrastructure provided by Microsoft Azure. Organisations across the planet are seeing great success deploying their websites on top of the Azure platform. See how you can join them using the new Azure Digital Marketing Solution sample implementations. In this session, learn how: - Understand the key services in Azure that will help you create great web experience - See how other companies are building successful web experiences with Azure - Learn how to get started creating your own modern website using the new Azure Sample Implementation.",
                StartDateTime = new DateTime(2017, 8, 16, 2, 0, 0)
            }
        };
    }
}
