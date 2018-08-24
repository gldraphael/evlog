using System;
using Evlog.Infrastructure;
using Evlog.Infrastructure.DataModels;
using MongoDB.Driver;

namespace Evlog.UnitTests.Infrastructure
{
    public class MongoDbContextBuilder
    {
        private MongoConfig configuration;

        public MongoDbContext Build()
        {
            _ = configuration ?? throw new NullReferenceException("The configuration must be set. Call UseConfiguration() or UseDefaultConfiguration() on the builder first.");

            var mongoClient = new MongoClient(connectionString: configuration.ConnectionString);
            var database = mongoClient.GetDatabase(configuration.Database);
            var eventsCollection = database.GetCollection<EventPostDM>("Events");
            var usersCollection = database.GetCollection<UserDM>("Users");
            return new MongoDbContext(mongoClient, database, eventsCollection, usersCollection);
        }

        public MongoDbContextBuilder UseConfiguration(MongoConfig config)
        {
            this.configuration = config;
            return this;
        }

        public MongoDbContextBuilder UseDefaultConfiguration()
        {
            this.configuration = new MongoConfig {
                Host = "localhost",
                Port = "27017",
                ConnectTimeout = 2000,
                Database = Guid.NewGuid().ToString()
            };
            return this;
        }
    }
}
