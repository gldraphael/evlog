using Evlog.Domain.EventAggregate.Commands;
using Evlog.Domain.EventAggregate.Queries;
using Evlog.Domain.Events.Handlers;
using Evlog.Domain.UserAggregate.Commands;
using Evlog.Domain.UserAggregate.Queries;
using Evlog.Infrastructure;
using Evlog.Infrastructure.Commands;
using Evlog.Infrastructure.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evlog.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEvlogEventHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRegistrationCompletedHandler, RegistrationCompletedHandler>();
        }

        public static void AddEvlogMvc(this IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true)
                    .AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

    }
}
