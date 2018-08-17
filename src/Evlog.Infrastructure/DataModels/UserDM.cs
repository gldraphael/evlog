using System.Collections.Generic;

namespace Evlog.Infrastructure.DataModels
{
    public class UserDM
    {
        public string Email { get; set; }
        public bool IsVerified { get; set; }
        public IEnumerable<EventPostDM> PendingRegistrations { get; set; }
    }
}
