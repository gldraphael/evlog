using Evlog.Infrastructure.Data;
using Evlog.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Evlog.Web.Areas.Identity.IdentityHostingStartup))]
namespace Evlog.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddSingleton<IEmailSender, IdentityUIEmailSender>();
                services.AddDefaultIdentity<EvlogWebUserDM>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<AppDbContext>();
            });
        }
    }
}
