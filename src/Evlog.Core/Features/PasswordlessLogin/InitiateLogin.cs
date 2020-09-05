using Evlog.Core.Abstractions;
using Evlog.Core.Abstractions.Repositories;
using Evlog.Core.Exceptions;
using Evlog.Core.Services;
using MediatR;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Evlog.Core.Features.PasswordlessLogin
{
    public sealed class InitiateLogin : ICommand
    {
        public string Email { get; }
        public int? EventPostId { get; set; }

        public InitiateLogin(string email, int? eventPostId = null)
        {
            Email = email;
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
            // TODO: 2. don't use the word Evlog in the email subject/message.

            var user = await users.GetByEmailAsync(command.Email) ?? throw new UserNotFoundException(email: command.Email);
            var token = await identityService.GetLoginToken(user.Id);
            var loginLink = $"/identity/magiclink?email={HttpUtility.UrlEncode(user.Email)}&token={HttpUtility.UrlEncode(token)}"; // TODO: ... ಠ_ಠ	
            await emailService.SendEmail(
                emailAddress: user.Email,
                subject: "Log into Evlog.",
                htmlMessage: $"Please <a href=\"{loginLink}\">click here</a> to login."
            );
            return Unit.Value;
        }
    }
}
