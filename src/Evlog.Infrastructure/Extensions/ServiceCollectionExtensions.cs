using Evlog.Core.Entities.EventAggregate.Commands;
using Evlog.Core.Entities.EventAggregate.Queries;
using Evlog.Infrastructure.Commands;
using Evlog.Infrastructure.Data.Queries;
using Evlog.Infrastructure.Data.SeedStrategies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evlog.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEvlogDb(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("MySql");

            services.AddDbContext<AppDbContext>(o =>
            {
                o.UseMySql(connectionString, opts =>
                {
                    opts.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
                });
            });
            services.AddScoped<ISeedStrategy, DevSeedStrategy>();

            return services;
        }

        public static void AddEvlogQueries(this IServiceCollection services)
        {
            // Add EventPost queries
            services.AddTransient<IAllEventsQuery, AllEventsQuery>();
            services.AddTransient<IPastEventsQuery, PastEventsQuery>();
            services.AddTransient<IUpcomingEventsQuery, UpcomingEventsQuery>();
            services.AddTransient<IEventQuery, EventQuery>();
        }

        public static void AddEvlogCommands(this IServiceCollection services)
        {
            services.AddTransient<IRegisterUserCommand, RegisterUserCommand>();
        }
    }
}
