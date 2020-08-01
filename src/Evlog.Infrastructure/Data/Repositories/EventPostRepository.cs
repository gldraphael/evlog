using Evlog.Core.Abstractions.Repositories;
using Evlog.Core.Entities.EventAggregate;
using Evlog.Infrastructure.Data.DataModels;


namespace Evlog.Infrastructure.Data.Repositories
{
    public class EventPostRepository : EfRepository<EventPost, EventPostDM>, IEventPostRepository
    {
        public EventPostRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
