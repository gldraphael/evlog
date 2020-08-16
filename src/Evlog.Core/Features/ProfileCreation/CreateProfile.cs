using Evlog.Core.Abstractions;
using Evlog.Core.Abstractions.Repositories;
using Evlog.Core.Entities.UserAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Evlog.Core.Features.ProfileCreation
{
    public sealed class CreateProfile : ICommand
    {
        public int UserId { get; set; }
        public UserProfile Profile { get; }

        public CreateProfile(int userId, UserProfile profile)
        {
            UserId = userId;
            Profile = profile;
        }
    }

    public sealed class CreateProfileHandler : ICommandHandler<CreateProfile>
    {
        private readonly IUserRepository users;

        public CreateProfileHandler(IUserRepository users)
        {
            this.users = users;
        }

        public async Task<Unit> Handle(CreateProfile command, CancellationToken cancellationToken)
        {
            // TODO: validate profile

            var user = await users.GetByIdAsync(command.UserId);
            user.Profile = command.Profile;
            await users.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
