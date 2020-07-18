using System.Threading.Tasks;

namespace Evlog.Core
{
    public interface IEvlogQuery<T>
    {
        Task<T> QueryAsync();
    }
}
