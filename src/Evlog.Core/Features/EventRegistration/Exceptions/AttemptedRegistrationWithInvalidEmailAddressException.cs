using System;

namespace EvlogEvlog.Core.Features.EventRegistration.Exceptions
{
    [Serializable]
    public class AttemptedRegistrationWithInvalidEmailAddressException : Exception
    {
        public AttemptedRegistrationWithInvalidEmailAddressException(int eventPostId, string email)
            : this(message: $"Registration for event {eventPostId} was attempted from an invalid email address {email}.") { }

        public AttemptedRegistrationWithInvalidEmailAddressException() { }
        public AttemptedRegistrationWithInvalidEmailAddressException(string message) : base(message) { }
        public AttemptedRegistrationWithInvalidEmailAddressException(string message, Exception inner) : base(message, inner) { }
        protected AttemptedRegistrationWithInvalidEmailAddressException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
