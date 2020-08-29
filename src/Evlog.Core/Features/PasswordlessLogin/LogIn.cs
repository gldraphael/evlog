using Evlog.Core.Abstractions;
using Evlog.Core.Abstractions.Repositories;
using Evlog.Core.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Evlog.Core.Features.PasswordlessLogin
{
    public class LogIn : ICommand<LoginResult>
    {
        public string Email { get; }
        public string Token { get; }

        public LogIn(string email, string token)
        {
            Email = email;
            Token = token;
        }
    }

    public class LoginResult
    {
        public static readonly LoginResult Failure = new LoginResult(didSucceed: false, isProfileCreationPending: false);

        public bool Succeeded { get; }
        public bool IsProfileCreationPending { get; }

        public LoginResult(bool didSucceed, bool isProfileCreationPending)
        {
            Succeeded = didSucceed;
            IsProfileCreationPending = isProfileCreationPending;
        }
    }

    public class LogInHandler : ICommandHandler<LogIn, LoginResult>
    {
        private readonly IUserRepository users;
        private readonly IIdentityService identityService;

        public LogInHandler(IUserRepository users, IIdentityService identityService)
        {
            this.users = users;
            this.identityService = identityService;
        }

        public async Task<LoginResult> Handle(LogIn command, CancellationToken cancellationToken)
        {
            // TODO: Add token validation logic

            var user = await users.GetByEmailAsync(command.Email);
            if(user is null) return LoginResult.Failure;

            if (user.IsConfirmed is false)
            {
                await users.MarkEmailAsConfirmed(user.Id);
            }
            await identityService.Login(email: command.Email);
            return new LoginResult(didSucceed: true, isProfileCreationPending: user.Profile is null);
        }
    }
}
