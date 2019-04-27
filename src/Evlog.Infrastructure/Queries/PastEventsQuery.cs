using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evlog.Domain.EventAggregate;
using Evlog.Domain.EventAggregate.Queries;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Evlog.Infrastructure.Queries
{
    internal class PastEventsQuery : IPastEventsQuery
    {
        private readonly AppDbContext _db;

        public PastEventsQuery(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IList<EventPost>> QueryAsync() =>
            (await _db.Events.Where(x => x.StartDateTime < DateTime.UtcNow)
                .ToListAsync())
                .Adapt<List<EventPost>>();
    }
}
