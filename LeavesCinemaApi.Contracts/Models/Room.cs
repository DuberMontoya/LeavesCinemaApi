using LeavesCinemaApi.Contracts.Utilities;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LeavesCinemaApi.Contracts.Models
{
    public class Room
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public TypeRoom Type { get; set; }
        public int Capacity { get; set; }
        public StateRoom State { get; set; }
    }
}
