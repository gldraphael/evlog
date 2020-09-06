using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Evlog.Core.Abstractions.Repositories;
using Evlog.Core.Entities.UserAggregate;
using Evlog.Core.Exceptions;
using Evlog.Core.Features.ProfileCreation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Evlog.Web.Pages.Profile
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IMediator mediator;
        private readonly IUserRepository users;

        public CreateModel(IMediator mediator, IUserRepository users)
        {
            this.mediator = mediator;
            this.users = users;
        }

        [BindProperty] public CreateProfileVM VM { get; set; } = new CreateProfileVM();

        public async Task<IActionResult> OnGet()
        {
            var user = await users.GetByEmailAsync(User.Identity.Name!) ?? throw new UserNotFoundException(email: User.Identity.Name);
            VM.FullName = user.Profile?.FullName;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                await mediator.Send(new CreateProfile(email: User.Identity.Name!, new UserProfile(fullName: VM.FullName!)));
            }
            return RedirectToPage();
        }

        public class CreateProfileVM
        {
            [Required]
            public string? FullName { get; set; }
        }
    }
}
