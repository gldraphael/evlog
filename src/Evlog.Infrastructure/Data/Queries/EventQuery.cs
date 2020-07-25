using System.Threading.Tasks;
using Evlog.Core.Entities.EventAggregate;
using Evlog.Core.Entities.EventAggregate.Queries;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Evlog.Infrastructure.Data.Queries
{
    internal class EventQuery : IEventQuery
    {
        private readonly AppDbContext _db;

        public EventQuery(AppDbContext db)
        {
            _db = db;
        }

        public async Task<EventPost> QueryAsync(string slug) =>
            (await _db.EventPosts.SingleOrDefaultAsync(k => k.Slug == slug))
                ?.Adapt<EventPost>();
    }
}
