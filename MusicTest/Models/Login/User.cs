using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace MusicTest.Models.Login
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string email { get; set; }
        [JsonIgnore]
        public string password { get; set; }
    }
}
