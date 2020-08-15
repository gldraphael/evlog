using System;

namespace Evlog.Core.Features.EventRegistration.Exceptions
{

    [Serializable]
    public class AttemptedRegistrationForPastEventException : Exception
    {
        public AttemptedRegistrationForPastEventException(int eventPostId, string email, DateTime eventDateTime, DateTime attemptedAt)
            : this(message: $"Registration for event {eventPostId} scheduled for {eventDateTime} was attempted by {email} at {attemptedAt}.") { }

        public AttemptedRegistrationForPastEventException() { }
        public AttemptedRegistrationForPastEventException(string message) : base(message) { }
        public AttemptedRegistrationForPastEventException(string message, Exception inner) : base(message, inner) { }
        protected AttemptedRegistrationForPastEventException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
