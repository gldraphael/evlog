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

        public ViewEventModel(IEventQuery eventQuery)
        {
            _eventQuery = eventQuery;
        }

        public async Task<IActionResult> OnGetAsync(string slug)
        {
            Post = await _eventQuery.QueryAsync(slug);
            return Page();
        }
    }
}