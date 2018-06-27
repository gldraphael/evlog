using System.Collections.Generic;

namespace Evlog.Domain.Data.Queries
{
    public interface IPastEventsQuery : IEvlogQuery<IList<EventPost>>
    {

    }
}