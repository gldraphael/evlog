using System.Threading.Tasks;

namespace Evlog.Domain
{
    public interface IEventHandler<E>
    {
        Task HandleAsync(E @event);
    }
}
