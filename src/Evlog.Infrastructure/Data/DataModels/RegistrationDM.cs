using System.ComponentModel.DataAnnotations;

namespace Evlog.Infrastructure.Data.DataModels
{
    public class RegistrationDM
    {
        [Key]
        public int Id { get; set; }

        public int EventPostId { get; set; }
        public EventPostDM? EventPost { get; set; }

        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        public int? UserId { get; set; }
        public EvlogWebUserDM? User { get; set; }

        public bool IsVerified { get; set; }
    }
}
