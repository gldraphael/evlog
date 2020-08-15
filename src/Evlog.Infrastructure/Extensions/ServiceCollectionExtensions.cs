using Evlog.Core.Abstractions.Repositories;
using Evlog.Core.Entities.EventAggregate.Queries;
using Evlog.Core.Services;
using Evlog.Infrastructure.Data;
using Evlog.Infrastructure.Data.Configuration;
using Evlog.Infrastructure.Data.Queries;
using Evlog.Infrastructure.Data.Repositories;
using Evlog.Infrastructure.Data.SeedStrategies;
using Evlog.Infrastructure.Email.Configuration;
using Evlog.Infrastructure.Email.EmailProviders;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Evlog.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEvlogDb(this IServiceCollection services, IConfiguration config)
        {
            var mysqlConfig = config.GetSection("MySql").Get<MySqlConfig>();

            services.AddDbContext<AppDbContext>(o =>
            {
                o.UseMySql(mysqlConfig.ConnectionString, opts =>
                {
                    opts.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
                });
            });
            services.AddScoped<ISeedStrategy, DevSeedStrategy>();
            return services;
        }

        public static IServiceCollection AddEvlogRepositories(this IServiceCollection services)
        {
            // Add EventPost queries
            services.AddTransient<IEventPostRepository, EventPostRepository>();

            return services;
        }

        public static IServiceCollection AddEvlogQueries(this IServiceCollection services)
        {
            // Add EventPost queries
            services.AddTransient<IAllEventsQuery, AllEventsQuery>();
            services.AddTransient<IPastEventsQuery, PastEventsQuery>();
            services.AddTransient<IUpcomingEventsQuery, UpcomingEventsQuery>();
            services.AddTransient<IEventQuery, EventQuery>();

            return services;
        }

        public static IServiceCollection AddEmailService(this IServiceCollection services, IConfiguration config)
        {
            var emailConfigurationSection = config.GetSection("Email");
            var emailConfig = emailConfigurationSection.Get<EmailConfig>();
            services.Configure<EmailConfig>(emailConfigurationSection);

            switch (emailConfig.Provider)
            {
                case EmailProvider.SMTP:
                    services.Configure<SmtpConfig>(config.GetSection("SMTP"));
                    services.AddTransient<IEmailService, SmtpEmailService>();
                    break;

                default:
                case EmailProvider.Log:
                    services.AddSingleton<IEmailService, LogEmailService>();
                    break;
            }

            return services;
        }
    }
}
