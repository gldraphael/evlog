using System;

namespace Evlog.Domain
{
    public class EventPost
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }
        public string Excerpt { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? EndTime { get; set; }
        public bool IsSingleDayEvent => StartDateTime.Date == (EndDate?.Date ?? StartDateTime.Date);
    }
}
