using System.Threading.Tasks;
using Evlog.Domain.EventAggregate.Commands;
using Evlog.Domain.EventAggregate.Queries;
using Evlog.Domain.Events;
using Evlog.Domain.Events.Handlers;
using Evlog.Infrastructure.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Evlog.Infrastructure.Commands
{
    public class RegisterUserCommand : IRegisterUserCommand
    {
        private readonly AppDbContext _db;
        private readonly IRegistrationCompletedHandler _registrationCompletedEventHandler;

        public RegisterUserCommand(AppDbContext db,
            IRegistrationCompletedHandler registrationCompletedEventHandler)
        {
            _db = db;
            _registrationCompletedEventHandler = registrationCompletedEventHandler;
        }

        public async Task Execute(string eventSlug, string userEmail)
        {
            var post = await _db.Events.SingleOrDefaultAsync(p => p.Slug == eventSlug);
            post.Registrations.Add(new RegistrationDM { Email = userEmail });
            await _db.SaveChangesAsync();

            await _registrationCompletedEventHandler.HandleAsync(
                        new RegistrationCompletedEvent(eventSlug, userEmail));
        }
    }
}
