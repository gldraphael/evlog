using Evlog.Core.Abstractions;
using Evlog.Core.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Evlog.Core.Features.EventRegistration
{
    public sealed class EventRegistrationConfirmed : IDomainEvent
    {
        public int EventPostId { get; }
        public int UserId { get; set; }
        public string UserEmail { get; }

        public EventRegistrationConfirmed(int eventPostId, int userId, string userEmail)
        {
            UserEmail = userEmail;
            EventPostId = eventPostId;
            UserId = userId;
        }
    }

    public sealed class EventRegistrationConfirmedHandler : IDomainEventHandler<EventRegistrationConfirmed>
    {
        private readonly IEmailService emailService;

        public EventRegistrationConfirmedHandler(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        public async Task Handle(EventRegistrationConfirmed message, CancellationToken cancellationToken)
        {
            await emailService.SendEmail(
                    emailAddress: message.UserEmail,
                    subject: "Your registration for --event name-- is confirmed", // TODO: gotta do better :)
                    htmlMessage: "Congratulations! Your registration for --event name-- has been confirmed."
                );
        }
    }
}
