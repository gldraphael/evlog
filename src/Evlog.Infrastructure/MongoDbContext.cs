using Evlog.Infrastructure.DataModels;
using MongoDB.Driver;

namespace Evlog.Infrastructure
{
    public class MongoDbContext
    {
        public IMongoClient Client { get; }
        public IMongoDatabase Database { get; }
        public IMongoCollection<EventPostDM> Events { get; }
        public IMongoCollection<UserDM> Users { get; }

        public MongoDbContext(IMongoClient client,
            IMongoDatabase database,
            IMongoCollection<EventPostDM> eventsCollection,
            IMongoCollection<UserDM> usersCollection) {
                Client = client;
                Database = database;
                Events = eventsCollection;
                Users = usersCollection;
        }
    }
}
