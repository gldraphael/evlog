using Evlog.Core.Services;
using Evlog.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Evlog.Web.Areas.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<EvlogWebUserDM> signInManager;
        private readonly UserManager<EvlogWebUserDM> userManager;

        public IdentityService(SignInManager<EvlogWebUserDM> signInManager, UserManager<EvlogWebUserDM> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public Task<string> GetLoginLink(int userId, int? eventPostId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsCurrentUserLoggedIn() // TODO: implement this, or get rid of it
        {
            // throw new NotImplementedException();
            return Task.FromResult(false);
        }

        public async Task Login(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            await signInManager.SignInAsync(user, isPersistent: true);
        }
    }
}
