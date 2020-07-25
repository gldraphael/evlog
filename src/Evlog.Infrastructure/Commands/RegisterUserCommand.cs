using System.Threading.Tasks;
using Evlog.Core.Entities.EventAggregate.Commands;
using Evlog.Infrastructure.Data;
using Evlog.Infrastructure.Data.DataModels;
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
            var post = await db.EventPosts.SingleOrDefaultAsync(p => p.Slug == eventSlug);
            post.Registrations.Add(new RegistrationDM { Email = userEmail });
            await db.SaveChangesAsync();
        }
    }
}
