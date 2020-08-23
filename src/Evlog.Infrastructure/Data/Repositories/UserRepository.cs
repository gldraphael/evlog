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
                EmailConfirmed = evlogUser.IsConfirmed
            };
            await users.CreateAsync(dao);
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
            dao.EmailConfirmed = true;
            await users.UpdateAsync(dao);
        }

        public Task UpdateAsync(EvlogUser user)
        {
            //var dao = await users.FindByIdAsync($"{user.Id}");
            //// dao.Profile = user.Profile;
            //await users.UpdateAsync(dao);

            return Task.CompletedTask;
        }

        static EvlogUser FromDao(EvlogWebUserDM dao) =>
            new EvlogUser(dao.Email, isConfirmed: dao.EmailConfirmed);

    }
}
