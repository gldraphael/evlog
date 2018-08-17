using Evlog.Infrastructure.DataModels;
using MongoDB.Driver;

namespace Evlog.Infrastructure
{
    public abstract class MongoQueryCommandBase
    {
        protected readonly IMongoClient _client;
        protected readonly IMongoDatabase _database;
        protected readonly IMongoCollection<EventPostDM> _events;
        protected readonly IMongoCollection<UserDM> _users;

        public MongoQueryCommandBase(
            IMongoClient client,
            IMongoDatabase database,
            IMongoCollection<EventPostDM> events,
            IMongoCollection<UserDM> users)
        {
            _client = client;
            _database = database;
            _events = events;
            _users = users;
        }

        protected MongoQueryCommandBase(
            IMongoClient client,
            IMongoDatabase database,
            IMongoCollection<EventPostDM> events)
            : this(client: client, database: database, events: events, users: null)
        { }

        protected MongoQueryCommandBase(
            IMongoClient client,
            IMongoDatabase database,
            IMongoCollection<UserDM> users)
            : this(client: client, database: database, users: users, events: null)
        { }

    }
}
