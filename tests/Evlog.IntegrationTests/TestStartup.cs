using System;
using Evlog.Infrastructure;
using Evlog.Infrastructure.Data;
using Evlog.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evlog.IntegrationTests
{
    public sealed class TestStartup : Startup
    {
        private readonly IConfiguration config;

        public TestStartup(IConfiguration configuration) : base(configuration)
        {
            this.config = configuration;
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            var databaseName = $"evlog-itests-{Guid.NewGuid()}";
            var connectionString = config.GetConnectionString("MySql").Replace("evlogitestdb", databaseName);
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                options.EnableSensitiveDataLogging();
            });

            base.ConfigureServices(services);

            // Override services here...
            //
        }
    }
}
