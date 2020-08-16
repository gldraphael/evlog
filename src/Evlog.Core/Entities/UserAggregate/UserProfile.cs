using Evlog.Core.SharedKernel;
using System.Collections.Generic;

namespace Evlog.Core.Entities.UserAggregate
{
    public sealed class UserProfile : ValueObject
    {
        public string FullName { get; }

        public UserProfile(string fullName)
        {
            FullName = fullName;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FullName;
        }
    }
}
