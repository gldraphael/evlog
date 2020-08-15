using System;

namespace Evlog.Core.Exceptions
{

    [Serializable]
    public class EventPostNotFoundException : Exception
    {
        public EventPostNotFoundException(int eventPostId) : this(message: $"EventPost with Id {eventPostId} could not be found.")
        {

        }

        public EventPostNotFoundException() { }
        public EventPostNotFoundException(string message) : base(message) { }
        public EventPostNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected EventPostNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
