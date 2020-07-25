using System.Threading.Tasks;
using Evlog.Infrastructure.Extensions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Evlog.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using var host = CreateWebHostBuilder(args).Build();
            await host.SeedAndApplyPendingMigrationsAsync();
            await host.RunAsync();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
