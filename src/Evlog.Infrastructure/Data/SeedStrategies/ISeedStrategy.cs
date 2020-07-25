using System.Threading.Tasks;

namespace Evlog.Infrastructure.Data.SeedStrategies
{
    interface ISeedStrategy
    {
        Task SeedAsync();
    }
}
