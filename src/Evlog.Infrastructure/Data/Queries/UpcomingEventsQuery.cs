using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evlog.Core.Entities.EventAggregate;
using Evlog.Core.Entities.EventAggregate.Queries;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Evlog.Infrastructure.Data.Queries
{
    internal class UpcomingEventsQuery : IUpcomingEventsQuery
    {
        private readonly AppDbContext _db;

        public UpcomingEventsQuery(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IList<EventPost>> QueryAsync() =>
            (await _db.EventPosts.Where(x => x.StartDateTime >= DateTime.UtcNow)
                .ToListAsync())
                .Adapt<List<EventPost>>();
    }
}
