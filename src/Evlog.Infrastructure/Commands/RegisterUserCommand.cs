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
        private readonly IRegistrationInitiatedHandler _registrationInitiatedEventHandler;

        public RegisterUserCommand(IMongoCollection<EventPostDM> events,
            IRegistrationInitiatedHandler registrationInitiatedEventHandler)
        {
            _events = events;
            _registrationInitiatedEventHandler = registrationInitiatedEventHandler;
        }

        public async Task Execute(string eventSlug, string userEmail)
        {
            await _registrationInitiatedEventHandler.HandleAsync(
                        new RegistrationInitiatedEvent(eventSlug, userEmail));

            var update = Builders<EventPostDM>.Update.AddToSet(x => x.Registrations, new RegistrationDM { Email = userEmail} );
            await _events.UpdateOneAsync(e => e.Slug == eventSlug, update);
        }
    }
}
