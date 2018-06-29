using System;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Evlog.Domain
{
    public class EventPost
    {
        [BsonId]
        public ObjectId Id { get; set; }
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
    }
}
