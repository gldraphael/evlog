using System.Threading.Tasks;
using Evlog.Domain.UserAggregate;
using Evlog.Domain.UserAggregate.Queries;
using Evlog.Infrastructure.DataModels;
using Mapster;
using MongoDB.Driver;

namespace Evlog.Infrastructure.Queries
{
    public class UserQuery : IUserQuery
    {
        private readonly MongoDbContext _db;

        public UserQuery(MongoDbContext db)
        {
            _db = db;
        }

        public async Task<User> QueryAsync(string email) =>
            (await _db.Users.Find<UserDM>(u => u.Email == email)
                .SingleOrDefaultAsync())
                .Adapt<User>();
    }
}
