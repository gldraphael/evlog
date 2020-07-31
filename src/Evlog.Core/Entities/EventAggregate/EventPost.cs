using Evlog.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Evlog.Core.Entities.EventAggregate
{
    public class EventPost : Entity, IAggregateRoot
    {
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }
        public string Excerpt => Description ??  string.Join(" ", Body.Split().Take(25));
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? EndTime { get; set; }
        public bool IsSingleDayEvent => StartDateTime.Date == (EndDate?.Date ?? StartDateTime.Date);
        public IEnumerable<Announcement> Announcements { get; set; }
    }
}
