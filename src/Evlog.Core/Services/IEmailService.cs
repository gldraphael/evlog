using System.Threading.Tasks;

namespace Evlog.Core.Services
{
    public interface IEmailService
    {
        Task SendEmail(string emailAddress, string subject, string htmlMessage);
    }
}
