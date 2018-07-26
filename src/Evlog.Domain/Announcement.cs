using System;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Evlog.Domain
{
    public class Announcement
    {
        public DateTime CreatedOn { get; set; }
        public DateTime LastEditedOn { get; set; }
        public string Text { get; set; }
        public string LongText { get; set; }
    }
}
