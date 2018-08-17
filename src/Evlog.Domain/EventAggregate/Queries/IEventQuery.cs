using System.Threading.Tasks;
using Evlog.Domain.EventAggregate;

namespace Evlog.Domain.EventAggregate.Queries
{
    public interface IEventQuery
    {
        Task<EventPost> QueryAsync(string slug);
    }
}
