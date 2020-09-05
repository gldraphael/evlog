using Evlog.Core.Features.PasswordlessLogin;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Evlog.Web.Areas.Identity
{
    public class MagicLinkController : Controller
    {
        private readonly IMediator mediator;

        public MagicLinkController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("/identity/magiclink")]
        public async Task<IActionResult> Login([FromQuery] string email, [FromQuery] string token, [FromQuery] string? to)
        {
            var result = await mediator.Send(new LogIn(email, token));
            if(result?.Succeeded is true)
            {
                if(result.IsProfileCreationPending)
                {
                    return RedirectToPage("/Profile/Create");
                }
                return Redirect(to ?? "/");
            }
            return Unauthorized(); // show a nice page!
        }
    }
}
