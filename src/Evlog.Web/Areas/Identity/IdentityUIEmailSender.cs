using Evlog.Core.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace Evlog.Web.Areas.Identity
{
    /// <summary>
    /// This class exists for ASP.NET UI. DO NOT use this.
    /// Use Evlog.Core.Services.IEmailService instead.
    /// </summary>
    public class IdentityUIEmailSender : IEmailSender
    {
        private readonly IEmailService emailService;

        public IdentityUIEmailSender(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage) =>
            await emailService.SendEmail(email, subject, htmlMessage);
    }
}
