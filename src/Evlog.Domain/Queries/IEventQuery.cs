using System.Threading.Tasks;
using Evlog.Domain.EventAggregate;

namespace Evlog.Domain.Queries
{
    public interface IEventQuery
    {
        Task<EventPost> QueryAsync(string slug);
    }
}
