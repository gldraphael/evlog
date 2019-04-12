using Evlog.Infrastructure.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Evlog.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<EventPostDM> Events { get; set; }
        public DbSet<UserDM> Users { get; set; }
        public DbSet<RegistrationDM> Registrations { get; set; }
    }
}
