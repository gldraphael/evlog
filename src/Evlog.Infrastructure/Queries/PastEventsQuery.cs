using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evlog.Domain;
using Evlog.Domain.Queries;
using MongoDB.Driver;

namespace Evlog.Infrastructure.Queries
{
    public class PastEventsQuery : MongoQueryCommandBase, IPastEventsQuery
    {
        public PastEventsQuery(IMongoClient client, IMongoDatabase database, IMongoCollection<EventPost> events) : base(client, database, events) => _ = 0;

        public async Task<IList<EventPost>> QueryAsync() =>
            await (await _events.FindAsync(x => x.StartDateTime < DateTime.UtcNow)).ToListAsync();
    }
}
