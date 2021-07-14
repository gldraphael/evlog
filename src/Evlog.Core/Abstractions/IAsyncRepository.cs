using Evlog.Core.SharedKernel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evlog.Core.Abstractions
{
    public interface IAsyncRepository<T> where T : Entity, IAggregateRoot
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> CountAsync();
    }
}
