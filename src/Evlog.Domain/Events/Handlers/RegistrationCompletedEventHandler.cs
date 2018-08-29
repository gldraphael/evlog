using System.Threading.Tasks;

namespace Evlog.Domain.Events.Handlers
{
    public class RegistrationCompletedHandler : IRegistrationCompletedHandler
    {
        public Task HandleAsync(RegistrationCompletedEvent @event)
        {
            // TODO: create a user if the user doesn't exist
            return Task.FromResult(0);
        }
    }
    public interface IRegistrationCompletedHandler : IEventHandler<RegistrationCompletedEvent>
    { }
}
