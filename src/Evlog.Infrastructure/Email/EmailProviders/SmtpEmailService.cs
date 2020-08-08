using Evlog.Core.Services;
using Evlog.Infrastructure.Email.Configuration;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;

namespace Evlog.Infrastructure.Email.EmailProviders
{
    public class SmtpEmailService : IEmailService
    {
        private readonly IOptions<EmailConfig> options;
        private readonly IOptions<SmtpConfig> smtpOptions;

        public SmtpEmailService(IOptions<EmailConfig> options, IOptions<SmtpConfig> smtpOptions)
        {
            this.options = options;
            this.smtpOptions = smtpOptions;
        }

        public async Task SendEmail(string emailAddress, string subject, string htmlMessage)
        {
            var sender = new MailboxAddress(name: options.Value.FromName, address: options.Value.FromEmail);
            var recepient = MailboxAddress.Parse(emailAddress);
            var message = new MimeMessage
            {
                Sender = sender,
                Subject = subject,
                Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage }
            };
            message.From.Add(sender);
            message.To.Add(recepient);

            var smtpOpts = smtpOptions.Value;
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(
                host: smtpOpts.Host, 
                port: smtpOpts.Port, 
                smtpOpts.Tls ? SecureSocketOptions.StartTls : SecureSocketOptions.None);
            await smtp.AuthenticateAsync(smtpOpts.Username, smtpOpts.Password);
            await smtp.SendAsync(message);
            await smtp.DisconnectAsync(true);
        }
    }
}
