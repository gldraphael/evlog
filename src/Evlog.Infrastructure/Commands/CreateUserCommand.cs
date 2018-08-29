using System.Threading.Tasks;
using Evlog.Domain.UserAggregate.Commands;
using Evlog.Domain.UserAggregate.Queries;
using Evlog.Infrastructure.DataModels;
using MongoDB.Driver;

namespace Evlog.Infrastructure.Commands
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly IMongoCollection<UserDM> _users;
        private readonly IUserExistsQuery _userExists;

        public CreateUserCommand(IMongoCollection<UserDM> users, IUserExistsQuery userExists)
        {
            this._users = users;
            this._userExists = userExists;
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
            await _users.InsertOneAsync(user);
        }
    }
}
