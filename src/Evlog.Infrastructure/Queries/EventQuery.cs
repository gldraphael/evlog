using System;
using System.Threading.Tasks;
using Evlog.Domain.EventAggregate;
using Evlog.Domain.EventAggregate.Queries;
using Evlog.Infrastructure.DataModels;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Evlog.Infrastructure.Queries
{
    internal class EventQuery : IEventQuery
    {
        private readonly AppDbContext _db;

        public EventQuery(AppDbContext db)
        {
            _db = db;
        }

        public async Task<EventPost> QueryAsync(string slug) =>
            (await _db.Events.SingleOrDefaultAsync(k => k.Slug == slug))
                .Adapt<EventPost>();
    }
}
