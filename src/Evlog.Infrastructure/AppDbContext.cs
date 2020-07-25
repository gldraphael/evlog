using Evlog.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Evlog.Infrastructure
{
    public class AppDbContext : IdentityDbContext<EvlogWebUserDM, IdentityRole<int>, int>
    {
        public DbSet<EventPostDM>    EventPosts     => Set<EventPostDM>();
        public DbSet<RegistrationDM> Registrations  => Set<RegistrationDM>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }
    }
}
