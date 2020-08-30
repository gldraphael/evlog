using Microsoft.AspNetCore.Identity;

namespace Evlog.Infrastructure.Data.DataModels
{
    public class EvlogWebUserDM : IdentityUser<int>
    {
        [PersonalData]
        public string? FullName { get; set; }
    }
}
