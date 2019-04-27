using Evlog.Infrastructure.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Evlog.Infrastructure
{
    internal class AppDbContext : DbContext
    {
        public DbSet<EventPostDM> Events { get; set; }
        public DbSet<UserDM> Users { get; set; }
        public DbSet<RegistrationDM> Registrations { get; set; }
        public DbSet<AnnouncementDM> Announcements { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }
    }
}
