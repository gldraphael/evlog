namespace Evlog.Infrastructure.DataModels
{
    public class RegistrationDM
    {
        public int Id { get; set; }

        public int EventPostId { get; set; }
        public EventPostDM EventPost { get; set; }

        public string Email { get; set; }
    }
}
