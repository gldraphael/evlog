using Evlog.Core.Entities.UserAggregate;
using System.Threading.Tasks;

namespace Evlog.Core.Abstractions.Repositories
{
    public interface IUserRepository// : IAsyncRepository<EvlogUser>
    {
        Task<EvlogUser?> GetByEmailAsync(string userEmail);
        Task MarkEmailAsConfirmed(int userId);
        Task AddAsync(EvlogUser evlogUser);
        Task<EvlogUser?> GetByIdAsync(int userId);
        Task UpdateAsync(EvlogUser user);
    }
}
