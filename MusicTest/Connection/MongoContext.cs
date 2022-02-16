using MongoDB.Driver;
using MusicTest.Helpers;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MusicTest.Connection
{
    public class MongoContext
    {
        
        public static IMongoDatabase Database()
        {
            string MongoDatabaseName = "Music"; 
            string conectionstring = "mongodb+srv://musictest:54lXz14MM5icwfII@cluster0.0n1vv.mongodb.net/Music?retryWrites=true&w=majority"; 
            var _client = new MongoClient(conectionstring);
            var _database = _client.GetDatabase(MongoDatabaseName);

            return _database;
        }
    }
}
