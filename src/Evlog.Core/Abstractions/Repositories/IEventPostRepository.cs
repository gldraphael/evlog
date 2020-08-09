using Evlog.Core.Entities.EventAggregate;

namespace Evlog.Core.Abstractions.Repositories
{
    public interface IEventPostRepository : IAsyncRepository<EventPost>
    {
        
    }
}
