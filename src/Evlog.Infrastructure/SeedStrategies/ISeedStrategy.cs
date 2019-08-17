using System.Threading.Tasks;

namespace Evlog.Infrastructure.SeedStrategies
{
    interface ISeedStrategy
    {
        Task SeedAsync();
    }
}
