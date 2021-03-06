using Evlog.Core.Abstractions;
using Evlog.Core.Internal.Extensions;
using Evlog.Core.SharedKernel;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Evlog.Core.Entities.EventAggregate
{
    public class EventPost : Entity, IAggregateRoot
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        private string? slug;
        [AllowNull]
        public string Slug
        {
            get
            {
                if(slug is null)
                {
                    slug = Title.Slugify();
                }
                return slug;
            }
            set => slug = value?.Slugify();
        }
        public string? BodyMarkdown { get; set; }
        public string? BodyHtml { get; set; }

        public DateTime StartTimeUtc { get; set; }
        public DateTime? EndTimeUtc { get; set; }


        public string Excerpt => Description ?? string.Empty;
        public bool IsSingleDayEvent => StartTimeUtc.Date == (EndTimeUtc?.Date ?? StartTimeUtc.Date);

        public void RenderMarkdown()
        {
            BodyHtml = BodyMarkdown?.RenderMarkdownAsHtml();
        }
    }
}
