using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evlog.Core.Entities.EventAggregate;
using Evlog.Core.Entities.EventAggregate.Queries;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Evlog.Infrastructure.Queries
{
    internal class AllEventsQuery : IAllEventsQuery
    {
        private readonly AppDbContext _db;

        public AllEventsQuery(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IList<EventPost>> QueryAsync() =>
            (await _db.Events.ToListAsync())
                .Adapt<List<EventPost>>();
    }
}
