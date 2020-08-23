using Evlog.Core.Abstractions;
using Evlog.Core.SharedKernel;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evlog.Infrastructure.Data.Repositories
{
    // See: https://github.com/dotnet-architecture/eShopOnWeb/blob/master/src/Infrastructure/Data/EfRepository.cs
    public class EfRepository<T, M> : IAsyncRepository<T>
        where T : Entity, IAggregateRoot
        where M : class
    {
        protected AppDbContext Db { get; }

        public EfRepository(AppDbContext dbContext)
        {
            Db = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(int id) =>
            (await Db.Set<M>().FindAsync(id)).Adapt<T>();

        public async Task<IReadOnlyList<T>> ListAllAsync() =>
            await Db.Set<M>().ProjectToType<T>().ToListAsync();

        public async Task<int> CountAsync() =>
            await Db.Set<M>().CountAsync();

        public async Task<T> AddAsync(T entity)
        {
            await Db.Set<M>().AddAsync(entity.Adapt<M>());
            await Db.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            Db.Entry(entity.Adapt<M>()).State = EntityState.Modified;
            await Db.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            Db.Set<T>().Remove(entity);
            await Db.SaveChangesAsync();
        }
    }
}
