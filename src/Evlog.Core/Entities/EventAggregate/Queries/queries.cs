using Evlog.Core.Abstractions;
using System.Collections.Generic;

namespace Evlog.Core.Entities.EventAggregate.Queries
{
    public interface IAllEventsQuery : IEvlogQuery<IList<EventPost>> { }
    public interface IUpcomingEventsQuery : IEvlogQuery<IList<EventPost>> { }
    public interface IPastEventsQuery : IEvlogQuery<IList<EventPost>> { }
}
