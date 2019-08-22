using Evlog.Domain.EventAggregate;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evlog.Infrastructure.Repositories
{
    internal class EventPostRepository : IEventPostRepository
    {
        private readonly AppDbContext _db;
        public EventPostRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<EventPost>> GetAll() =>
            (await _db.Events.ToListAsync())
                .Adapt<List<EventPost>>();

        public async Task<IEnumerable<EventPost>> GetPast() =>
            (await _db.Events.Where(x => x.StartDateTime < DateTime.UtcNow)
                .ToListAsync())
                .Adapt<List<EventPost>>();

        public async Task<IEnumerable<EventPost>> GetUpcoming() =>
            (await _db.Events.Where(x => x.StartDateTime >= DateTime.UtcNow)
                .ToListAsync())
                .Adapt<List<EventPost>>();

    }
}
