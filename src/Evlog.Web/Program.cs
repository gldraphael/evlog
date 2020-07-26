using System.Threading.Tasks;
using Evlog.Infrastructure.Extensions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

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
                .ConfigureLogging((host, l) =>
                {
                    l.ClearProviders();
                    var logger = new LoggerConfiguration()
                                    .ReadFrom.Configuration(host.Configuration)
                                    .CreateLogger();
                    l.AddSerilog(logger);
                })
                .UseStartup<Startup>();
    }
}
