using System.Threading.Tasks;

namespace Evlog.Core.Services
{
    public interface IIdentityService
    {
        Task<string> GetLoginLink(int userId, int? eventPostId); // TODO: Could replace this with a InitiatePasswordlessLogin command
                                                                 //       if we think of password-less login as its own feature.
        Task Login(int userId);
        Task<bool> IsCurrentUserLoggedIn(); // not sure if this is a good idea...
    }
}
