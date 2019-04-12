using System;
using System.Threading.Tasks;
using Evlog.Domain.UserAggregate;
using Evlog.Domain.UserAggregate.Queries;
using Evlog.Infrastructure.DataModels;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Evlog.Infrastructure.Queries
{
    public class UserQuery : IUserQuery
    {
        private readonly AppDbContext _db;

        public UserQuery(AppDbContext db)
        {
            _db = db;
        }

        public async Task<User> QueryAsync(string email) =>
            (await _db.Users.SingleOrDefaultAsync(u => u.Email == email))
                .Adapt<User>();
    }
}
