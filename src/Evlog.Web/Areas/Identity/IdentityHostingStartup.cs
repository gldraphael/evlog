using Evlog.Infrastructure.Data;
using Evlog.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

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

                services.ConfigureApplicationCookie(options =>
                {
                    options.AccessDeniedPath = "/identity/account/accessdenied";
                    options.ExpireTimeSpan = TimeSpan.FromDays(14);
                    //options.LoginPath = "/Identity/Account/Login"; // TODO: Passwordless login page
                    options.SlidingExpiration = true;

                    options.Cookie.Name = "__evlog_auth";
                    options.Cookie.HttpOnly = true;
                    options.Cookie.IsEssential = true;
                    options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                });

                services.AddAntiforgery(options =>
                {
                    options.FormFieldName = "__xsrf";
                    options.HeaderName = "X-CSRF-TOKEN";
                    options.SuppressXFrameOptionsHeader = false;

                    options.Cookie.Name = "__evlog_xsrf";
                    options.Cookie.IsEssential = true;
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                });
            });


        }
    }
}
