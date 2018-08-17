using System.Threading.Tasks;
using Evlog.Domain.UserAggregate;
using Evlog.Domain.UserAggregate.Queries;
using Evlog.Infrastructure.DataModels;
using Mapster;
using MongoDB.Driver;

namespace Evlog.Infrastructure.Queries
{
    public class UserQuery : MongoQueryCommandBase, IUserQuery
    {
        public UserQuery(IMongoClient client, IMongoDatabase database, IMongoCollection<UserDM> users)
        : base(client, database, users)
        { }

        public async Task<User> QueryAsync(string email) =>
            (await _users.Find<UserDM>(u => u.Email == email)
                .SingleOrDefaultAsync())
                .Adapt<User>();
    }
}
