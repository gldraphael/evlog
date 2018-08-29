using Evlog.Domain.EventAggregate;

namespace Evlog.Domain.Events
{
    public class RegistrationCompletedEvent : IEvent
    {
        /// <summary>
        /// The slug of the event the registration was initiated for
        /// </summary>
        /// <value></value>
        public string EventPostSlug { get; }

        /// <summary>
        /// The email used to make the registration
        /// </summary>
        /// <value></value>
        public string Email { get; }

        public RegistrationCompletedEvent(string eventpostSlug, string email)
        {
            EventPostSlug = eventpostSlug;
            Email = email;
        }
    }
}
