using System.Threading.Tasks;
using MongoDB.Bson;

namespace Evlog.Domain.Queries
{
    public interface IEventQuery
    {
        Task<EventPost> QueryAsync(string slug);
    }
}
