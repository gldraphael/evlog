using Evlog.Core.Services;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Evlog.Infrastructure.Email.EmailProviders
{
    public class LogEmailService : IEmailService
    {
        private readonly ILogger<LogEmailService> logger;

        public LogEmailService(ILogger<LogEmailService> logger)
        {
            this.logger = logger;
        }

        public Task SendEmail(string emailAddress, string subject, string htmlMessage)
        {
            logger.LogInformation("Email {@emailAddress}; Subject: {@subject}\n" +
                "Message: {@htmlMessage}", emailAddress, subject, htmlMessage);
            return Task.CompletedTask;
        }
    }
}
