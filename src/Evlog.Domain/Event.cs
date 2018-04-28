using System;

namespace Evlog.Domain
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
