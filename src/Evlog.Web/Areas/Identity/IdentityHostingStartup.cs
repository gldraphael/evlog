using System;
using Evlog.Web.Areas.Identity.Data;
using Evlog.Web.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Evlog.Web.Areas.Identity.IdentityHostingStartup))]
namespace Evlog.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<EvlogWebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("EvlogWebContextConnection")));

                services.AddDefaultIdentity<EvlogWebUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<EvlogWebContext>();
            });
        }
    }
}