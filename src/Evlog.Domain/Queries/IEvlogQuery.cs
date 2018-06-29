using System.Threading.Tasks;

namespace Evlog.Domain.Queries
{
    public interface IEvlogQuery<T>
    {
        Task<T> QueryAsync();
    }
}
