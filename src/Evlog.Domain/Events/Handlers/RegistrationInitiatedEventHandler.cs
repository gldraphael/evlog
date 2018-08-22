using System.Threading.Tasks;

namespace Evlog.Domain.Events.Handlers
{
    public class RegistrationInitiatedHandler : IRegistrationInitiatedHandler
    {
        public Task HandleAsync(RegistrationInitiatedEvent @event)
        {
            // TODO: create a user if the user doesn't exist
            return Task.FromResult(0);
        }
    }
    public interface IRegistrationInitiatedHandler : IEventHandler<RegistrationInitiatedEvent>
    { }
}
