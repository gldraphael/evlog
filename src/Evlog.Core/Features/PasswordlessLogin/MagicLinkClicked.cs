using Evlog.Core.Abstractions;
using Evlog.Core.Abstractions.Repositories;
using Evlog.Core.Exceptions;
using Evlog.Core.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Evlog.Core.Features.PasswordlessLogin
{
    public sealed class MagicLinkClicked : IDomainEvent
    {
        public int UserId { get; }
        // TODO: some kind of token needs to be set here
    }

    public sealed class MagicLinkClickedHandler : IDomainEventHandler<MagicLinkClicked>
    {
        private readonly IUserRepository users;
        private readonly IIdentityService identityService;

        public MagicLinkClickedHandler(IUserRepository users, IIdentityService identityService)
        {
            this.users = users;
            this.identityService = identityService;
        }

        public async Task Handle(MagicLinkClicked message, CancellationToken cancellationToken)
        {
            // TODO: Add token validation logic

            var user = await users.GetByIdAsync(message.UserId) ?? throw new UserNotFoundException(userId: message.UserId);
            if(user.IsConfirmed is false)
            {
                await users.MarkEmailAsConfirmed(message.UserId);
            }

            // TODO: login only if the user has a profile
            // else get a profile created first
            await identityService.Login(message.UserId);
        }
    }
}
