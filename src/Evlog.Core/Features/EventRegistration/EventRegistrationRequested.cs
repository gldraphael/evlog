using Evlog.Core.Abstractions;
using Evlog.Core.Abstractions.Repositories;
using Evlog.Core.Exceptions;
using Evlog.Core.Features.EventRegistration.Exceptions;
using EvlogEvlog.Core.Features.EventRegistration.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Evlog.Core.Features.EventRegistration
{
    public class EventRegistrationRequested : ICommand
    {
        public int EventPostId { get; }
        public string Email { get; }
        public EventRegistrationRequested(int eventPostId, string email)
        {
            EventPostId = eventPostId;
            Email = email;
        }
    }

    public class EventRegistrationRequestedHandler : ICommandHandler<EventRegistrationRequested>
    {
        private readonly IEventPostRepository eventPosts;
        private readonly IMediator mediator;

        public EventRegistrationRequestedHandler(IEventPostRepository eventPosts, IMediator mediator)
        {
            this.eventPosts = eventPosts;
            this.mediator = mediator;
        }

        public async Task<Unit> Handle(EventRegistrationRequested command, CancellationToken cancellationToken)
        {
            if(false) // TODO: validate email address
                      // Is this even required? Users can't register without an account...
                      // might as well let the account creation logic perform this validation.
            {
                throw new AttemptedRegistrationWithInvalidEmailAddressException(eventPostId: command.EventPostId, command.Email);
            }

            // 2. Validate if the registration is not too late
            var eventPost = await eventPosts.GetByIdAsync(command.EventPostId) ?? throw new EventPostNotFoundException(command.EventPostId);
            var currentTimeUtc = DateTime.UtcNow;
            if(currentTimeUtc >= eventPost.StartTimeUtc)
            {
                throw new AttemptedRegistrationForPastEventException(
                    eventPostId: command.EventPostId,
                    email: command.Email,
                    eventDateTime: eventPost.StartTimeUtc,
                    attemptedAt: currentTimeUtc
                );
            }

            // TODO: Save the registration somewhere


            await mediator.Publish(new UserRegisteredForEvent(eventPostId: command.EventPostId, userEmail: command.Email));
            return Unit.Value;
        }
    }
}
