using Evlog.Infrastructure.DataModels;
using MongoDB.Driver;

namespace Evlog.Infrastructure
{
    public abstract class MongoQueryCommandBase
    {
        protected IMongoClient _client { get; private set; }
        protected IMongoDatabase _database { get; private set; }
        protected IMongoCollection<EventPostDM> _events { get; private set; }

        public MongoQueryCommandBase(
            IMongoClient client,
            IMongoDatabase database,
            IMongoCollection<EventPostDM> events)
        {
            _client = client;
            _database = database;
            _events = events;
        }

    }
}