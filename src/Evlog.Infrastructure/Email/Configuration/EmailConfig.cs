namespace Evlog.Infrastructure.Email.Configuration
{
    public class EmailConfig
    {
        public string FromName { get; set; } = null!;
        public string FromEmail { get; set; } = null!;
        public EmailProvider Provider { get; set; }
    }

    public enum EmailProvider
    {
        Log,
        SMTP
    }
}
