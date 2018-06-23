using System.Threading.Tasks;
using Evlog.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Evlog.Web.Controllers
{
    [Route("/api/exp")]
    public class ExpController : Controller
    {
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            try
            {
                await MongoExperiment.RunAsync();
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
