using Microsoft.Extensions.DependencyInjection;

namespace Evlog.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEvlogEventHandlers(this IServiceCollection services)
        {
            
        }

        public static void AddEvlogMvc(this IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true)
                    .AddRazorPages();
        }
    }
}
