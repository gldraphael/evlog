using System.Threading.Tasks;
using Evlog.Domain.EventAggregate.Commands;
using Evlog.Domain.EventAggregate.Queries;
using Evlog.Infrastructure.DataModels;
using MongoDB.Driver;

namespace Evlog.Infrastructure.Commands
{
    public class RegisterUserCommand : IRegisterUserCommand
    {
        private readonly IMongoCollection<EventPostDM> _events;
        public RegisterUserCommand(IMongoCollection<EventPostDM> events)
        {
            _events = events;
        }

        public async Task Execute(string eventSlug, string userEmail)
        {
            // TODO: raise RegistrationAttempted event

            var update = Builders<EventPostDM>.Update.AddToSet(x => x.Registrations, new RegistrationDM { Email = userEmail} );
            await _events.UpdateOneAsync(e => e.Slug == eventSlug, update);
        }
    }
}
