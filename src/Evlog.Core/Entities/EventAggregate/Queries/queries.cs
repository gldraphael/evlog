
using System.Collections.Generic;
using Evlog.Core.Entities.EventAggregate;

namespace Evlog.Core.Entities.EventAggregate.Queries
{
    public interface IAllEventsQuery : IEvlogQuery<IList<EventPost>> { }
    public interface IUpcomingEventsQuery : IEvlogQuery<IList<EventPost>> { }
    public interface IPastEventsQuery : IEvlogQuery<IList<EventPost>> { }

}
