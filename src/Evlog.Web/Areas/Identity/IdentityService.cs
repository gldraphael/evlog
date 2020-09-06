using Evlog.Core.Services;
using Evlog.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Evlog.Web.Areas.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<EvlogWebUserDM> signInManager;
        private readonly UserManager<EvlogWebUserDM> userManager;
        private readonly IHttpContextAccessor httpContext;

        public IdentityService(
            SignInManager<EvlogWebUserDM> signInManager,
            UserManager<EvlogWebUserDM> userManager,
            IHttpContextAccessor httpContext)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.httpContext = httpContext;
        }

        public Task<string> GetLoginToken(int userId) => Task.FromResult("heya"); // TODO: implement this for real

        public bool IsCurrentUserLoggedIn() => httpContext.HttpContext.User.Identity.IsAuthenticated;

        public async Task Login(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            await signInManager.SignInAsync(user, isPersistent: true);
        }
    }
}
