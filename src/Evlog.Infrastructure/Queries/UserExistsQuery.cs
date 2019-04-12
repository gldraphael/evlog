using System;
using System.Linq;
using System.Threading.Tasks;
using Evlog.Domain.UserAggregate.Queries;
using Evlog.Infrastructure.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Evlog.Infrastructure.Queries
{
    public class UserExistsQuery : IUserExistsQuery
    {
        private readonly AppDbContext _db;

        public UserExistsQuery(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> QueryAsync(string email) =>
            await _db.Users.AnyAsync(u => u.Email == email);
    }
}
