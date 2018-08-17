using System.Threading.Tasks;

namespace Evlog.Domain.EventAggregate.Commands
{
    public interface IRegisterUserCommand
    {
        Task Execute(string eventSlug, string userEmail);
    }
}