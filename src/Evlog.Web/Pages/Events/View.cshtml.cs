using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Evlog.Domain.EventAggregate;
using Evlog.Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Evlog.Web.Pages.Events
{
    public class ViewEventModel : PageModel
    {
        private readonly IEventQuery _eventQuery;

        public EventPost Post { get; set; }

        [BindProperty]
        public RegisterRequestVM RegisterVM { get; set; }

        public ViewEventModel(IEventQuery eventQuery)
        {
            _eventQuery = eventQuery;
        }

        public async Task<IActionResult> OnGetAsync(string slug)
        {
            Post = await _eventQuery.QueryAsync(slug);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string slug)
        {
            // TODO: Register the user for the event here

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
