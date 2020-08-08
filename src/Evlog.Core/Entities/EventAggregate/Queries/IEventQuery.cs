using System.Threading.Tasks;

namespace Evlog.Core.Entities.EventAggregate.Queries
{
    public interface IEventQuery
    {
        Task<EventPost?> QueryAsync(string slug);
    }
}
