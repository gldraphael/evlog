using System.Threading.Tasks;
using Evlog.Domain.UserAggregate.Commands;
using Evlog.Domain.UserAggregate.Queries;
using Evlog.Infrastructure.DataModels;

namespace Evlog.Infrastructure.Commands
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly AppDbContext _db;
        private readonly IUserExistsQuery _userExists;

        public CreateUserCommand(IUserExistsQuery userExists, AppDbContext db)
        {
            _userExists = userExists;
            _db = db;
        }

        public async Task ExecuteAsync(string email)
        {
            if(await _userExists.QueryAsync(email))
            {
                return;
            }

            var user = new UserDM
            {
                Email = email
            };
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
        }
    }
}
