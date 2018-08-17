using System.Threading.Tasks;

namespace Evlog.Domain
{
    public interface IEvlogQuery<T>
    {
        Task<T> QueryAsync();
    }
}
