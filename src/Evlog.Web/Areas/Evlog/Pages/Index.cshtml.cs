using Evlog.Core.Abstractions.Repositories;
using Evlog.Core.Entities.EventAggregate;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evlog.Web.Areas.Evlog.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IEventPostRepository eventPosts;

        public IReadOnlyList<EventPost>? EventPosts { get; set; }

        public IndexModel(IEventPostRepository eventPosts)
        {
            this.eventPosts = eventPosts;
        }

        public async Task OnGet()
        {
            EventPosts = await eventPosts.ListAllAsync();
        }
    }
}
