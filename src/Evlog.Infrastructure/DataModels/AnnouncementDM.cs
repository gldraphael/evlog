using System;

namespace Evlog.Infrastructure.DataModels
{
    public class AnnouncementDM
    {
        public DateTime CreatedOn { get; set; }
        public DateTime LastEditedOn { get; set; }
        public string Text { get; set; }
        public string LongText { get; set; }
    }
}