using System;
using System.Linq;

namespace Evlog.Core.Entities.EventAggregate
{
    public class Announcement
    {
        public DateTime CreatedOn { get; set; }
        public DateTime LastEditedOn { get; set; }
        public string Text { get; set; }
        public string LongText { get; set; }
    }
}
