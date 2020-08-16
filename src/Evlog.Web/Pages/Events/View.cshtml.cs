using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Evlog.Core.Entities.EventAggregate;
using Evlog.Core.Entities.EventAggregate.Queries;
using Evlog.Core.Features.EventRegistration;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Evlog.Web.Pages.Events
{
    public class ViewEventModel : PageModel
    {
        private readonly IEventQuery eventQuery;
        private readonly IMediator mediatr;

        public EventPost? Post { get; set; }

        [BindProperty]
        public RegisterRequestVM RegisterVM { get; set; } = new RegisterRequestVM();

        public ViewEventModel(IEventQuery eventQuery, IMediator mediatr)
        {
            this.eventQuery = eventQuery;
            this.mediatr = mediatr;
        }

        public async Task<IActionResult> OnGetAsync(string slug)
        {
            Post = await eventQuery.QueryAsync(slug);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string slug)
        {
            if(ModelState.IsValid)
            {
                Post = await eventQuery.QueryAsync(slug);
                if(Post != null)
                {
                    await mediatr.Send(new EventRegistrationRequested(Post.Id, RegisterVM.Email));
                }
            }

            return RedirectToPage(routeValues: new { slug });
        }


        public class RegisterRequestVM
        {
            [EmailAddress, Required]
            public string Email { get; set; } = null!;
        }

    }
}
