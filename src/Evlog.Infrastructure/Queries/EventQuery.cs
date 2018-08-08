using System.Threading.Tasks;
using Evlog.Domain.EventAggregate;
using Evlog.Domain.Queries;
using Evlog.Infrastructure.DataModels;
using Mapster;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Evlog.Infrastructure.Queries
{
    public class EventQuery : MongoQueryCommandBase, IEventQuery
    {
        public EventQuery(IMongoClient client, IMongoDatabase database, IMongoCollection<EventPostDM> events) : base(client, database, events) => _ = 0;

        public async Task<EventPost> QueryAsync(string slug) =>
            (await (await _events.FindAsync<EventPostDM>(k => k.Slug == slug)).SingleOrDefaultAsync()).Adapt<EventPost>();
    }
}
