using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Evlog.Infrastructure.DataModels
{
    public class UserDM
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Email { get; set; }
        public bool IsVerified { get; set; }
        public IEnumerable<EventPostDM> PendingRegistrations { get; set; }
    }
}
