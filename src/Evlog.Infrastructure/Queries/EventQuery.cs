using System.Threading.Tasks;
using Evlog.Domain.EventAggregate;
using Evlog.Domain.EventAggregate.Queries;
using Evlog.Infrastructure.DataModels;
using Mapster;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Evlog.Infrastructure.Queries
{
    public class EventQuery : IEventQuery
    {
        private readonly MongoDbContext _db;

        public EventQuery(MongoDbContext db)
        {
            this._db = db;
        }

        public async Task<EventPost> QueryAsync(string slug) =>
            (await _db.Events.Find<EventPostDM>(k => k.Slug == slug)
                .SingleOrDefaultAsync()).Adapt<EventPost>();
    }
}
