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
        private readonly IEventQuery _eventQuery;
        private readonly IRegisterUserCommand _registerUser;

        public EventPost Post { get; set; }

        [BindProperty]
        public RegisterRequestVM RegisterVM { get; set; }

        public ViewEventModel(IEventQuery eventQuery, IRegisterUserCommand registerUser)
        {
            _eventQuery = eventQuery;
            _registerUser = registerUser;
        }

        public async Task<IActionResult> OnGetAsync(string slug)
        {
            Post = await _eventQuery.QueryAsync(slug);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string slug)
        {
            await _registerUser.Execute(slug, RegisterVM.Email);

            Post = await _eventQuery.QueryAsync(slug);
            return Page();
        }


        public class RegisterRequestVM
        {
            [EmailAddress]
            public string Email { get; set; }
        }

    }
}
