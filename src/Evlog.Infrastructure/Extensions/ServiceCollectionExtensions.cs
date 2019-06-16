using Evlog.Domain.EventAggregate.Commands;
using Evlog.Domain.EventAggregate.Queries;
using Evlog.Domain.UserAggregate.Commands;
using Evlog.Domain.UserAggregate.Queries;
using Evlog.Infrastructure.Commands;
using Evlog.Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evlog.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEvlogDb(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("MySql");;
            services.AddDbContext<AppDbContext>(o =>
            {
                o.UseMySql(connectionString, opts =>
                {
                    opts.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
                });
            });

            return services;
        }

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
    }
}