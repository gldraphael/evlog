namespace Evlog.Domain.UserAggregate
{
    public class User : IAggregateRoot
    {
        public string Email { get; set; }
        public bool IsVerififed { get; set; }
    }
}