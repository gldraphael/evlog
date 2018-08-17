using System.Threading.Tasks;
using Evlog.Domain.UserAggregate;

namespace Evlog.Domain.UserAggregate.Queries
{
    public interface IUserQuery
    {
        Task<User> QueryAsync(string email);
    }
}
