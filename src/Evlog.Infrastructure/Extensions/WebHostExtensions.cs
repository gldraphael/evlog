using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Evlog.Infrastructure.Extensions
{
    public static class WebHostExtensions
    {
        public static async Task EnsureDbCreated(this IWebHost host) // TODO: Change this to ApplyPendingMigrations()
        {
            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                await db.Database.EnsureCreatedAsync();
            }
        }
    }
}
