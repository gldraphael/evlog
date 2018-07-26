using System.Threading.Tasks;
using Evlog.Domain.EventAggregate;
using Evlog.Domain.Queries;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Evlog.Infrastructure.Queries
{
    public class EventQuery : MongoQueryCommandBase, IEventQuery
    {
        public EventQuery(IMongoClient client, IMongoDatabase database, IMongoCollection<EventPost> events) : base(client, database, events) => _ = 0;

        public async Task<EventPost> QueryAsync(string slug) =>
            await (await _events.FindAsync<EventPost>(k => k.Slug == slug)).SingleOrDefaultAsync();
    }
}
