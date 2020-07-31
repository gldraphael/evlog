using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Evlog.Core;
using Evlog.Core.Abstractions;
using Evlog.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evlog.Infrastructure.Data.Repositories
{
    // See: https://github.com/dotnet-architecture/eShopOnWeb/blob/master/src/Infrastructure/Data/EfRepository.cs
    public class EfRepository<T> : IAsyncRepository<T> where T : Entity, IAggregateRoot
    {
        protected AppDbContext Db { get; }

        public EfRepository(AppDbContext dbContext)
        {
            Db = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await Db.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await Db.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.CountAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await Db.Set<T>().AddAsync(entity);
            await Db.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            await Db.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            Db.Set<T>().Remove(entity);
            await Db.SaveChangesAsync();
        }

        public async Task<T> FirstAsync(ISpecification<T> spec)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.FirstAsync();
        }

        public async Task<T> FirstOrDefaultAsync(ISpecification<T> spec)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            var evaluator = new SpecificationEvaluator<T>();
            return evaluator.GetQuery(Db.Set<T>().AsQueryable(), spec);
        }
    }
}
