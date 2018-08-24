using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evlog.Domain.EventAggregate;
using Evlog.Domain.EventAggregate.Queries;
using Evlog.Infrastructure.DataModels;
using Mapster;
using MongoDB.Driver;

namespace Evlog.Infrastructure.Queries
{
    public class UpcomingEventsQuery : IUpcomingEventsQuery
    {
        private readonly MongoDbContext _db;

        public UpcomingEventsQuery(MongoDbContext db)
        {
            this._db = db;
        }

        public async Task<IList<EventPost>> QueryAsync() =>
            (await _db.Events.Find(x => x.StartDateTime >= DateTime.UtcNow)
                .ToListAsync())
                .Adapt<List<EventPost>>();
    }
}
