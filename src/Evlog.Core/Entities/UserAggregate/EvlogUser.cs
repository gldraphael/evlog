using Evlog.Core.Abstractions;
using Evlog.Core.SharedKernel;

namespace Evlog.Core.Entities.UserAggregate
{
    public class EvlogUser : Entity, IAggregateRoot
    {
        public string Email { get; }
        public bool IsConfirmed { get; }
        public UserProfile? Profile { get; set; }

        public EvlogUser(string email, bool isConfirmed)
        {
            Email = email;
            IsConfirmed = isConfirmed;
        }
    }
}
