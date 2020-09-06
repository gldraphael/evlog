using Evlog.Core.Abstractions;
using Evlog.Core.Abstractions.Repositories;
using Evlog.Core.Entities.UserAggregate;
using Evlog.Core.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Evlog.Core.Features.ProfileCreation
{
    public sealed class CreateProfile : ICommand
    {
        public string Email { get; set; }
        public UserProfile Profile { get; }

        public CreateProfile(string email, UserProfile profile)
        {
            Email = email;
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

            var user = await users.GetByEmailAsync(command.Email) ?? throw new UserNotFoundException(command.Email);
            user.Profile = command.Profile;
            await users.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
