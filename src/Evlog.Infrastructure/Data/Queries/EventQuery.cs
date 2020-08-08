using System.Threading.Tasks;
using Evlog.Core.Entities.EventAggregate;
using Evlog.Core.Entities.EventAggregate.Queries;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Evlog.Infrastructure.Data.Queries
{
    internal class EventQuery : IEventQuery
    {
        private readonly AppDbContext db;

        public EventQuery(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<EventPost?> QueryAsync(string slug) =>
            (await db.EventPosts.SingleOrDefaultAsync(k => k.Slug == slug))
                ?.Adapt<EventPost>();
    }
}
