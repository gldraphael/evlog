using System.Threading.Tasks;
using Evlog.Domain.UserAggregate.Commands;

namespace Evlog.Domain.Events.Handlers
{
    public class RegistrationCompletedHandler : IRegistrationCompletedHandler
    {
        private readonly ICreateUserCommand createUserCommand;
        public RegistrationCompletedHandler(ICreateUserCommand createUserCommand)
        {
            this.createUserCommand = createUserCommand;
        }

        public Task HandleAsync(RegistrationCompletedEvent @event)
        {
            // Create a new user when a registration is made
            return createUserCommand.ExecuteAsync(@event.Email);
        }
    }
    public interface IRegistrationCompletedHandler : IEventHandler<RegistrationCompletedEvent>
    { }
}
