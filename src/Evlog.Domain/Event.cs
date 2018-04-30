using System;

namespace Evlog.Domain
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? EndTime { get; set; }
        public bool IsSingleDayEvent => StartDateTime.Date == (EndDate?.Date ?? StartDateTime.Date);
    }
}
