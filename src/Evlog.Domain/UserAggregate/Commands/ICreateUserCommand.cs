using System.Threading.Tasks;

namespace Evlog.Domain.UserAggregate.Commands
{
    public interface ICreateUserCommand
    {
        Task ExecuteAsync(string email);
    }
}
