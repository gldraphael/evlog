using Evlog.Core.Entities.EventAggregate;
using System.Collections.Generic;

namespace Evlog.Core.Abstractions.Repositories
{
    public interface IEventPostRepository : IAsyncRepository<EventPost>
    {
        
    }
}
