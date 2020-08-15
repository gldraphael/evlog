using Evlog.Core.Abstractions;
using Evlog.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Evlog.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(IDomainEvent));
            services.AddEvlogDb(Configuration)
                    .AddEvlogRepositories()
                    .AddEvlogQueries()
                    .AddEmailService(Configuration);

            services.AddRouting(options => options.LowercaseUrls = true)
                .AddRazorPages(o =>
                {
                    o.Conventions.AuthorizeAreaFolder("Evlog", "/");
                });
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
