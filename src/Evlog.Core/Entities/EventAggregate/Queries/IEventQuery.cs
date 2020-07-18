using System.Threading.Tasks;
using Evlog.Core.Entities.EventAggregate;

namespace Evlog.Core.Entities.EventAggregate.Queries
{
    public interface IEventQuery
    {
        Task<EventPost> QueryAsync(string slug);
    }
}
