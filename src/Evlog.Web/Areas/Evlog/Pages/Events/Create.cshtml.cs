using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Evlog.Core.Abstractions.Repositories;
using Evlog.Core.Entities.EventAggregate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Evlog.Web.Areas.Evlog.Pages.Events
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> logger;
        private readonly IEventPostRepository eventPosts;

        public CreateModel(ILogger<CreateModel> logger, IEventPostRepository eventPosts)
        {
            this.logger = logger;
            this.eventPosts = eventPosts;
        }



        [BindProperty] public CreateVM VM { get; set; } = new CreateVM();

        public async Task<IActionResult> OnPost()
        {
            logger.LogDebug("Creating post with: {@CreateVM}", VM);
            var post = new EventPost
            {
                Title = VM.Title ?? "Untitled",
                Slug = VM.Slug,
                Description = VM.Description,
                BodyMarkdown = VM.Markdown
            };
            post.RenderMarkdown();
            await eventPosts.AddAsync(post);

            return RedirectToPage("/Index", new { area = "Evlog" });
        }

        public class CreateVM
        {
            [Required]
            public string? Title { get; set; }

            public string? Slug { get; set; }
            public string? Description { get; set; }

            [Required]
            public string? Markdown { get; set; }
        }
    }
}
