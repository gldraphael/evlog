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
                services.AddDefaultIdentity<EvlogWebUserDM>(options => 
                { 
                    options.SignIn.RequireConfirmedAccount = true;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;

                    options.Password.RequiredUniqueChars = 5;
                    options.Password.RequiredLength = 12; // TODO: make this configurable
                })
                    .AddEntityFrameworkStores<AppDbContext>();
            });
        }
    }
}
