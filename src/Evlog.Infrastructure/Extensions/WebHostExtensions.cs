using System.Threading.Tasks;
using Evlog.Infrastructure.Data;
using Evlog.Infrastructure.Data.SeedStrategies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Evlog.Infrastructure.Extensions
{
    public static class WebHostExtensions
    {
        public static async Task SeedAndApplyPendingMigrationsAsync(this IWebHost host)
        {
            using var scope = host.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await db.Database.MigrateAsync();

            var seeder = scope.ServiceProvider.GetService<ISeedStrategy>();
            if (seeder is null) return;
            await seeder.SeedAsync();
        }
    }
}
