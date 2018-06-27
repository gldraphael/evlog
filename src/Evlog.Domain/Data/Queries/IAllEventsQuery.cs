using System.Collections.Generic;

namespace Evlog.Domain.Data.Queries
{
    public interface IAllEventsQuery : IEvlogQuery<IList<EventPost>>
    {
        
    }
}
