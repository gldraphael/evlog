using System;

namespace Evlog.Core.Exceptions
{

    [Serializable]
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(int userId) : this(message: $"The user with Id {userId}.")
        {

        }

        public UserNotFoundException() { }
        public UserNotFoundException(string message) : base(message) { }
        public UserNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected UserNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
