using Evlog.Core.Abstractions;
using Evlog.Core.Abstractions.Repositories;
using Evlog.Core.Exceptions;
using Evlog.Core.Features.EventRegistration.Exceptions;
using Evlog.Core.SharedKernel;
using EvlogEvlog.Core.Features.EventRegistration.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Evlog.Core.Features.EventRegistration
{
    public class RegisterForEvent : ICommand
    {
        public int EventPostId { get; }
        public string Email { get; }
        public RegisterForEvent(int eventPostId, string email)
        {
            EventPostId = eventPostId;
            Email = email;
        }
    }

    public class RegisterForEventHandle : IAsyncCommandHandler<RegisterForEvent>
    {
        private readonly IEventPostRepository eventPosts;
        private readonly IMediator mediator;

        public RegisterForEventHandle(IEventPostRepository eventPosts, IMediator mediator)
        {
            this.eventPosts = eventPosts;
            this.mediator = mediator;
        }

        public async Task<Unit> Handle(RegisterForEvent command, CancellationToken cancellationToken)
        {
            if(false) // TODO: 1. validate email address
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


            await mediator.Publish(new UserRegisteredForEvent());
            return Unit.Value;
        }
    }
}
