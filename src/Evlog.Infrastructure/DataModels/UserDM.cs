using System.Collections.Generic;

namespace Evlog.Infrastructure.DataModels
{
    public class UserDM
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool IsVerified { get; set; }
        public IList<EventPostDM> PendingRegistrations { get; set; } = new List<EventPostDM>();
    }
}
