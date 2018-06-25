using System.Threading.Tasks;
using Evlog.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Evlog.Web.Controllers
{
    [Route("/api/exp")]
    public class ExpController : Controller
    {
        [HttpGet("")]
        public async Task<IActionResult> Get([FromServices]IOptions<MongoConfig> monoConfigOptions)
        {
            try
            {
                await MongoExperiment.RunAsync(monoConfigOptions.Value);
                return Ok("Success");
            }
            catch
            {
                var x = Ok("Failure");
                x.StatusCode = 500;
                return x;
            }
        }
    }
}
