using Evlog.Core.Abstractions;
using Evlog.Core.Abstractions.Repositories;
using Evlog.Core.Exceptions;
using Evlog.Core.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Evlog.Core.Features.PasswordlessLogin
{
    public sealed class InitiateLogin : ICommand
    {
        public int UserId { get; }
        public int? EventPostId { get; set; }

        public InitiateLogin(int userId, int? eventPostId = null)
        {
            UserId = userId;
            EventPostId = eventPostId;
        }
    }

    public sealed class InitiateLoginHandler : ICommandHandler<InitiateLogin>
    {
        private readonly IEmailService emailService;
        private readonly IIdentityService identityService;
        private readonly IUserRepository users;

        public InitiateLoginHandler(IEmailService emailService, IIdentityService identityService, IUserRepository users)
        {
            this.emailService = emailService;
            this.identityService = identityService;
            this.users = users;
        }

        public async Task<Unit> Handle(InitiateLogin command, CancellationToken cancellationToken)
        {
            // TODO: 1. update the subject, depending on what the email is being sent for
            // TODO: 2. don't use the word Evlog.

            var user = await users.GetByIdAsync(command.UserId) ?? throw new UserNotFoundException(userId: command.UserId);
            var loginLink = await identityService.GetLoginLink(command.UserId, command.EventPostId);
            await emailService.SendEmail(
                emailAddress: user.Email,
                subject: "Log into Evlog.",
                htmlMessage: $"Please <a href=\"{loginLink}\">click here</a> to login."
            );
            return Unit.Value;
        }
    }
}
