
using System.Collections.Generic;

namespace Evlog.Domain.Queries
{
    public interface IAllEventsQuery : IEvlogQuery<IList<EventPost>> { }
    public interface IUpcomingEventsQuery : IEvlogQuery<IList<EventPost>> { }
    public interface IPastEventsQuery : IEvlogQuery<IList<EventPost>> { }

}
