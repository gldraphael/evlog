using System.Threading.Tasks;

namespace Evlog.Domain.UserAggregate.Queries
{
    public interface IUserExistsQuery
    {
        Task<bool> QueryAsync(string email);
    }
}