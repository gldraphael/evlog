using System.Threading.Tasks;
using Evlog.Domain.EventAggregate.Commands;
using Evlog.Domain.EventAggregate.Queries;
using Evlog.Domain.Events;
using Evlog.Domain.Events.Handlers;
using Evlog.Infrastructure.DataModels;
using MongoDB.Driver;

namespace Evlog.Infrastructure.Commands
{
    public class RegisterUserCommand : IRegisterUserCommand
    {
        private readonly IMongoCollection<EventPostDM> _events;
        private readonly IRegistrationCompletedHandler _registrationCompletedEventHandler;

        public RegisterUserCommand(IMongoCollection<EventPostDM> events,
            IRegistrationCompletedHandler registrationCompletedEventHandler)
        {
            _events = events;
            _registrationCompletedEventHandler = registrationCompletedEventHandler;
        }

        public async Task Execute(string eventSlug, string userEmail)
        {
            var update = Builders<EventPostDM>.Update.AddToSet(x => x.Registrations, new RegistrationDM { Email = userEmail} );
            await _events.UpdateOneAsync(e => e.Slug == eventSlug, update);

            await _registrationCompletedEventHandler.HandleAsync(
                        new RegistrationCompletedEvent(eventSlug, userEmail));
        }
    }
}
