using Ardalis.Specification;
using Evlog.Core.SharedKernel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evlog.Core.Abstractions
{
    public interface IAsyncRepository<T> where T : Entity, IAggregateRoot
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> CountAsync(ISpecification<T> spec);
        Task<T> FirstAsync(ISpecification<T> spec);
        Task<T> FirstOrDefaultAsync(ISpecification<T> spec);
    }
}
