using System.Threading.Tasks;
using Evlog.Domain.EventAggregate.Commands;
using Evlog.Infrastructure.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Evlog.Infrastructure.Commands
{
    internal class RegisterUserCommand : IRegisterUserCommand
    {
        private readonly AppDbContext db;

        public RegisterUserCommand(AppDbContext db)
        {
            this.db = db;
        }

        public async Task Execute(string eventSlug, string userEmail)
        {
            var post = await db.Events.SingleOrDefaultAsync(p => p.Slug == eventSlug);
            post.Registrations.Add(new RegistrationDM { Email = userEmail });
            await db.SaveChangesAsync();
        }
    }
}
