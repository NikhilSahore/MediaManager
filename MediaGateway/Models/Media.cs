using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MediaGateway.Models
{
    public class Media
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("event")]
        public string Event { get; set; }

        [BsonElement("location")]
        public Location Location { get; set; }

        [BsonElement("eventtime")]
        public string EventTime { get; set; }

        [BsonIgnore]
        public List<MediaFile> Photos { get; set; }

        [BsonIgnore]
        public List<MediaFile> Videos { get; set; }
    }

    public class MediaFile
    {
        [BsonIgnore]
        public IFormFile File { get; set; }
    }

    public class Location
    {
        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("latitude")]
        public double Latitude { get; set; }

        [BsonElement("longitude")]
        public double Longitude { get; set; }
    }
}