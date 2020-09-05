using Evlog.Core.Abstractions;
using Evlog.Core.Abstractions.Repositories;
using Evlog.Core.Entities.UserAggregate;
using Evlog.Core.Features.PasswordlessLogin;
using Evlog.Core.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Evlog.Core.Features.EventRegistration
{
    public sealed class UserRegisteredForEvent : IDomainEvent
    {
        public int EventPostId { get; }
        public string UserEmail { get; }

        public UserRegisteredForEvent(int eventPostId, string userEmail)
        {
            EventPostId = eventPostId;
            UserEmail = userEmail;
        }
    }
    // TODO SIMPLIFY THIS
    public sealed class UserRegisteredForEventHandler : IDomainEventHandler<UserRegisteredForEvent>
    {
        private readonly IUserRepository users;
        private readonly IMediator mediator;
        private readonly IIdentityService identityService;

        public UserRegisteredForEventHandler(IUserRepository users, IMediator mediator, IIdentityService identityService)
        {
            this.users = users;
            this.mediator = mediator;
            this.identityService = identityService;
        }

        public async Task Handle(UserRegisteredForEvent message, CancellationToken cancellationToken)
        {
            var user = await users.GetByEmailAsync(message.UserEmail);
            if(user is null)
            {
                user = new EvlogUser(email: message.UserEmail, isConfirmed: false);
                await users.AddAsync(user);
            }
            else if(await identityService.IsCurrentUserLoggedIn()) // TODO: Also check if a user "profile" exists
            {
                // TODO: Persist the registration
                await mediator.Publish(new EventRegistrationConfirmed(message.EventPostId, user.Id, user.Email));
                return;
            }

            await mediator.Send(new InitiateLogin(email: message.UserEmail, eventPostId: message.EventPostId));
        }
    }
}
