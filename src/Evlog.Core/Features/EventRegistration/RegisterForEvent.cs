using Evlog.Core.Abstractions;

namespace Evlog.Core.Features.EventRegistration
{
    public class RegisterForEvent : ICommand
    {
        public string Email { get; }
        public RegisterForEvent(string email)
        {
            Email = email;
        }
    }
}
