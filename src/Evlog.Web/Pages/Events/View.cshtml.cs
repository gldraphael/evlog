using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Evlog.Core.Entities.EventAggregate;
using Evlog.Core.Entities.EventAggregate.Commands;
using Evlog.Core.Entities.EventAggregate.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Evlog.Web.Pages.Events
{
    public class ViewEventModel : PageModel
    {
        private readonly IEventQuery eventQuery;
        private readonly IRegisterUserCommand registerUserCommand;

        public EventPost? Post { get; set; }

        [BindProperty]
        public RegisterRequestVM RegisterVM { get; set; } = new RegisterRequestVM();

        public ViewEventModel(IEventQuery eventQuery, IRegisterUserCommand registerUser)
        {
            this.eventQuery = eventQuery;
            registerUserCommand = registerUser;
        }

        public async Task<IActionResult> OnGetAsync(string slug)
        {
            Post = await eventQuery.QueryAsync(slug);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string slug)
        {
            if(ModelState.IsValid) // TODO: print some error message, etc.
            {
                await registerUserCommand.Execute(slug, RegisterVM.Email);
            }
            
            return RedirectToPage();
        }


        public class RegisterRequestVM
        {
            [EmailAddress, Required]
            public string Email { get; set; } = null!;
        }

    }
}
