using System.Threading.Tasks;

namespace Evlog.Core.Entities.EventAggregate.Commands
{
    public interface IRegisterUserCommand
    {
        Task Execute(string eventSlug, string userEmail);
    }
}