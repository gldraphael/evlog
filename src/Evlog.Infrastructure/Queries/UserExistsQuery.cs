using System.Threading.Tasks;
using Evlog.Domain.UserAggregate.Queries;
using Evlog.Infrastructure.DataModels;
using MongoDB.Driver;

namespace Evlog.Infrastructure.Queries
{
    public class UserExistsQuery : IUserExistsQuery
    {
        private readonly MongoDbContext _db;

        public UserExistsQuery(MongoDbContext db)
        {
            this._db = db;
        }

        public async Task<bool> QueryAsync(string email) =>
            await _db.Users.Find(u => u.Email == email).AnyAsync();
    }
}
