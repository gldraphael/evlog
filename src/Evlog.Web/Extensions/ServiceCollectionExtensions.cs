using Evlog.Domain.EventAggregate.Commands;
using Evlog.Domain.EventAggregate.Queries;
using Evlog.Domain.Events.Handlers;
using Evlog.Domain.UserAggregate.Commands;
using Evlog.Domain.UserAggregate.Queries;
using Evlog.Infrastructure.Commands;
using Evlog.Infrastructure.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evlog.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEvlogQueries(this IServiceCollection services)
        {
            // Add EventPost queries
            services.AddTransient<IAllEventsQuery, AllEventsQuery>();
            services.AddTransient<IPastEventsQuery, PastEventsQuery>();
            services.AddTransient<IUpcomingEventsQuery, UpcomingEventsQuery>();
            services.AddTransient<IEventQuery, EventQuery>();

            // Add User queries
            services.AddTransient<IUserQuery, UserQuery>();
            services.AddTransient<IUserExistsQuery, UserExistsQuery>();
        }

        public static void AddEvlogCommands(this IServiceCollection services)
        {
            services.AddTransient<IRegisterUserCommand, RegisterUserCommand>();
            services.AddTransient<ICreateUserCommand, CreateUserCommand>();
        }

        public static void AddEvlogEventHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRegistrationCompletedHandler, RegistrationCompletedHandler>();
        }


        public static IServiceCollection AddDb(this IServiceCollection services, IConfiguration config)
        {
            var appsettings = config.GetSection("AppSettings").Get<AppSettings>();

            return services;
        }

        public static void AddEvlogMvc(this IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true)
                    .AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

    }
}
