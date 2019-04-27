using System;
using Evlog.Infrastructure;
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
            var databaseName = $"evlog-utests-{Guid.NewGuid()}";
            var connectionString = $"Server=localhost;Port=3307;Database={databaseName};User=root;Password=Pa5sw0rd;"; // TODO: DO NOT HARDCODE THIS!
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySql(connectionString);
                options.EnableSensitiveDataLogging(true);
            });

            base.ConfigureServices(services);

            // Override services here...
            //
        }
    }
}
