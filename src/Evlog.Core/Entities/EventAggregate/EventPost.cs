using Evlog.Core.SharedKernel;
using System;
using System.Linq;

namespace Evlog.Core.Entities.EventAggregate
{
    public class EventPost : Entity, IAggregateRoot
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string Slug { get; set; } = null!;
        public string? BodyMarkdown { get; set; }
        public string? BodyHtml { get; set; }

        public DateTime StartTimeUtc { get; set; }
        public DateTime? EndTimeUtc { get; set; }


        public string Excerpt => Description ?? string.Empty;
        public bool IsSingleDayEvent => StartTimeUtc.Date == (EndTimeUtc?.Date ?? StartTimeUtc.Date);
    }
}
