using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MusicTest.Models.Login;

namespace MusicTest.Models.Music
{
    public class Song
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string MusicGenre { get; set; }
        public bool IsPublic { get; set; }
        public Artist Artist { get; set; }
        public Album Album { get; set; }
        public string IdUser { get; set; }
    }

    public class Artist
    {
        [BsonId]
        public int IdArtist { get; set; }
        public string Name { get; set; }
    }

    public class Album
    {
        [BsonId]
        public int IdAlbum { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
    }
}
