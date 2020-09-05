using Evlog.Core.Abstractions.Repositories;
using Evlog.Core.Entities.UserAggregate;
using Evlog.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Evlog.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<EvlogWebUserDM> users;

        public UserRepository(UserManager<EvlogWebUserDM> users)
        {
            this.users = users;
        }

        public async Task AddAsync(EvlogUser evlogUser)
        {
            var dao = new EvlogWebUserDM
            {
                UserName = evlogUser.Email,
                Email = evlogUser.Email,
                LockoutEnabled = true,
                EmailConfirmed = evlogUser.IsConfirmed,
                FullName = evlogUser.Profile?.FullName
            };
            await users.CreateAsync(dao); // TOOD: check the result
        }

        public async Task<EvlogUser?> GetByEmailAsync(string userEmail)
        {
            var dao = await users.FindByNameAsync(userName: userEmail);
            return FromDao(dao);
        }

        public async Task<EvlogUser?> GetByIdAsync(int userId)
        {
            var dao = await users.FindByIdAsync($"{userId}"); // Maybe I should open an issue asking for a UserManager<TUser, TKey> or maybe it's already there in .NET 5 🤷🏾‍
            return FromDao(dao);
        }

        public async Task MarkEmailAsConfirmed(int userId)
        {
            var dao = await users.FindByIdAsync($"{userId}");
            if (dao is null) return;
            dao.EmailConfirmed = true;
            await users.UpdateAsync(dao);
        }

        public async Task UpdateAsync(EvlogUser user)
        {
            var dao = await users.FindByIdAsync($"{user.Id}");
            dao.FullName = user.Profile?.FullName;
            await users.UpdateAsync(dao);
        }

        static EvlogUser? FromDao(EvlogWebUserDM dao)
        {
            if (dao is null) return null;
            var profile = dao.FullName is null ? null : new UserProfile(dao.FullName);
            return new EvlogUser(dao.Email, isConfirmed: dao.EmailConfirmed)
            {
                Id = dao.Id,
                Profile = profile
            };
        }
    }
}
