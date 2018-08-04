const events = [
  {
    Title: "Azure App Services",
    Slug: "azure-app-services",
    Body: "Quickly create powerful cloud apps using a fully-managed platform. Quickly build, deploy and scale enterprise-grade web, mobile and API apps running on any platform A one hour webinar on Azure App Services.",
    StartDateTime: new Date("2018-04-30T15:00:00Z")
  },
  {
    Title: "High performance computing",
    Slug: "high-performance-computing",
    Body: "Tap into unlimited resources to scale your high performance computing (HPC) jobs—analysing large-scale data, running simulations and financial models and experimenting while reducing time to market.",
    StartDateTime: new Date("1983-05-01T15:00:00Z")
  },
  {
    Title: "Network Monitoring with Network Performance Monitor (NPM)",
    Slug: "network-monitoring-with-network-performance-monitor-npm",
    Body: "A one hour session introduction and QnA Network Monitoring with Network Performance Monitor (NPM).",
    StartDateTime: new Date("2018-05-08T12:00:00Z")
  },
  {
    Title: "Learn Machine Learning using Azure ML",
    Slug: "learn-machine-learning-using-azure-ml",
    Body: "Machine learning is current buzz word in our industry and everyone wants to know what it is. Machine learning is in our industry for very long from the ages of Alan Turing. But it has gained momentum and mostly possible due to the cloud compute power that is available now. With Azure ML we can do wonders with data. Implementing any machine learning algorithm is bunch of drag and drops that you need to in Azure ML Studio. \n\nIn this webinar you will be learning what machine learning is and how to choose an algorithm for your problem. Five questions to ask on choosing ML algorithm. Below are the agenda for our webinar: \n\nArtificial Intelligence Vs Machine learning Vs Deep learning \nWhat is Naive Bayes? \nWhat is feature and label? \nDifference between R and Python?",
    StartDateTime: new Date("2019-05-15T12:00:00Z"),
    Announcements: [
      {
        Text: "Here's an important announcement",
        LongText: "Congratulations on reading this super important announcement. It was quite important for you to have read this important announcement."
      }
    ]
  },
  {
    Title: "Webinar: Azure DevOps and Containers",
    Slug: "webinar-azure-devops-and-containers",
    Body: "It's time to modernize and future proof your applications. Learn how new constructs such as PaaS, web and mobile app services, Serverless, microservices, containers and others can do this while ensuring continuous innovation through end to end DevOps.",
    StartDateTime: new Date("2019-05-17T07:30:00Z")
  },
  {
    Title: "Building Modern Websites using Microsoft Azure",
    Slug: "building-modern-websites-using-microsoft-azure",
    Body: "Learn how to quickly build modern, secure, scalable and highly available websites using the powerful web infrastructure provided by Microsoft Azure. Organisations across the planet are seeing great success deploying their websites on top of the Azure platform. See how you can join them using the new Azure Digital Marketing Solution sample implementations. In this session, learn how: - Understand the key services in Azure that will help you create great web experience - See how other companies are building successful web experiences with Azure - Learn how to get started creating your own modern website using the new Azure Sample Implementation.",
    StartDateTime: new Date("2017-08-16T02:00:00Z")
  }
];



db = db.getSiblingDB('evlog');
db.dropDatabase();
db.Events.insertMany(events);
