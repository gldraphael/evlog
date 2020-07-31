using Evlog.Core.Abstractions.Repositories;
using Evlog.Core.Entities.EventAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evlog.Infrastructure.Data.Repositories
{
    public class EventPostRepository : EfRepository<EventPost>, IEventPostRepository
    {
        public EventPostRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
