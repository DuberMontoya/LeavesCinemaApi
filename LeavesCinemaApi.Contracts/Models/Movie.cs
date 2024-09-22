using LeavesCinemaApi.Contracts.Utilities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LeavesCinemaApi.Contracts.Models
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ReleaseDate { get; set; } = string.Empty;
        public Genre Genre { get; set; }
    }
}
