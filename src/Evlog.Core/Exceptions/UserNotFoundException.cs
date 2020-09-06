using System;

namespace Evlog.Core.Exceptions
{

    [Serializable]
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(int userId) : base(message: $"A user with Id {userId} was not found.")
        {

        }

        public UserNotFoundException(string? email) : base(message: $"A user with email {email} was not found.")
        {

        }

        public UserNotFoundException() { }
        public UserNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected UserNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
