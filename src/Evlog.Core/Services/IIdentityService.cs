using System.Threading.Tasks;

namespace Evlog.Core.Services
{
    public interface IIdentityService
    {
        Task<string> GetLoginToken(int userId);
        Task Login(string email);
        Task<bool> IsCurrentUserLoggedIn(); // not sure if this is a good idea...
    }
}
