using System.Threading.Tasks;

namespace Evlog.Core.Abstractions
{
    public interface IEvlogQuery<T>
    {
        Task<T> QueryAsync();
    }
}
