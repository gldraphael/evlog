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
                    opts.MigrationsAssembly(typeof(AppDbContext).AssemblyQualifiedName);
                });
            });

            return services;
        }
    }
}
