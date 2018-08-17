using System.Threading.Tasks;
using Evlog.Domain.UserAggregate.Queries;
using Evlog.Infrastructure.DataModels;
using MongoDB.Driver;

namespace Evlog.Infrastructure.Queries
{
    public class UserExistsQuery : MongoQueryCommandBase, IUserExistsQuery
    {
        public UserExistsQuery(IMongoClient client, IMongoDatabase database, IMongoCollection<UserDM> users) : base(client, database, users)
        { }

        public async Task<bool> QueryAsync(string email) =>
            await _users.Find(u => u.Email == email).AnyAsync();
    }
}
