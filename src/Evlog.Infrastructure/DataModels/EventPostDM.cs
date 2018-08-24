using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Evlog.Infrastructure.DataModels
{
    public class EventPostDM
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? EndTime { get; set; }
        public IList<AnnouncementDM> Announcements { get; set; } = new List<AnnouncementDM>();
        public IList<RegistrationDM> Registrations { get; set; } = new List<RegistrationDM>();
    }
}
