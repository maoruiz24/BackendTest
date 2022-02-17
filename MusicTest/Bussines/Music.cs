using System.Security.Claims;
using MusicTest.Models.Music;
using MusicTest.Connection;
using MongoDB.Driver;
using MusicTest.Models.Login;
using Microsoft.AspNetCore.Mvc.Filters;
using MongoDB.Bson;

namespace MusicTest.Bussines
{

    public interface IMusic
    {
        ResponseMusic AllSongs(int qPage, int perPage);
        ResponseMusic OneSong(string id);
        ResponseMusic Create(Song song);
        ResponseMusic Update(Song song);
        ResponseMusic Delete(string Id);
    }

    public class Music: IMusic
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public Music(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public ResponseMusic AllSongs(int qPage, int perPage)
        {
            try
            {
                User user = null;
                string _idUser = string.Empty;

                if (_contextAccessor.HttpContext != null)
                {
                    user = (User)_contextAccessor.HttpContext.Items["User"];
                    _idUser = user.Id.ToString();
                }

                var document = MongoContext.Database().GetCollection<Song>("Song");

                var songs = (from p in document.AsQueryable()
                             where ((p.IdUser.Equals(_idUser) & p.IsPublic.Equals(false)) | p.IsPublic.Equals(true))
                             select p).Skip((qPage -1) * perPage).Take(perPage).ToList();

                return new ResponseMusic
                {
                    codeError = "00",
                    msgError = "Successful",
                    Songs = songs
                };
            }
            catch (Exception ex)
            {
                return new ResponseMusic
                {
                    codeError = "01",
                    msgError = ex.Message,
                    Songs = new List<Song>()
                };
            }
        }

        public ResponseMusic OneSong(string id)
        {
            var songs = new List<Song>();

            try
            {
                User user = null;
                string _idUser = string.Empty;

                if (_contextAccessor.HttpContext != null)
                {
                    user = (User)_contextAccessor.HttpContext.Items["User"];
                    _idUser = user.Id.ToString();
                }

                var document = MongoContext.Database().GetCollection<Song>("Song");

                var _id = ObjectId.Parse(id);
                var song = (from p in document.AsQueryable()
                            where (p.Id.Equals(_id) &
                            (p.IdUser.Equals(_idUser) & p.IsPublic.Equals(false)) | p.IsPublic.Equals(true))
                            select p).FirstOrDefault();

                if (song == null)
                {
                    return new ResponseMusic
                    {
                        codeError = "00",
                        msgError = "Song didn't find in the database",
                        Songs = songs
                    };
                }
                else
                {
                    songs.Add(song);
                    return new ResponseMusic
                    {
                        codeError = "01",
                        msgError = "Successful",
                        Songs = songs
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseMusic
                {
                    codeError = "02",
                    msgError = ex.Message,
                    Songs = songs
                };
            }
        }

        public ResponseMusic Create(Song song)
        {
            var songs = new List<Song>();

            try
            {
                User user = null;
                string _idUser = string.Empty;

                if (_contextAccessor.HttpContext != null)
                {
                    user = (User)_contextAccessor.HttpContext.Items["User"];
                    _idUser = user.Id.ToString();
                }

                song.IdUser = _idUser;

                var document = MongoContext.Database().GetCollection<Song>("Song");
                document.InsertOne(song);

                songs.Add(song);

                return new ResponseMusic
                {
                    codeError = "00",
                    msgError = "Song created successfully",
                    Songs = songs
                };
            }
            catch(Exception ex)
            {
                return new ResponseMusic
                {
                    codeError = "02",
                    msgError = ex.Message,
                    Songs = songs
                };
            }
        }

        public ResponseMusic Update(Song song)
        {
            var songs = new List<Song>();

            try
            {
                var document = MongoContext.Database().GetCollection<Song>("Song");

                document.UpdateOne(Builders<Song>.Filter.Eq(x => x.Id, song.Id),
                                    Builders<Song>.Update.Set(x => x.Name, song.Name)
                                                           .Set(x => x.MusicGenre, song.MusicGenre)
                                                           .Set(x => x.IsPublic, song.IsPublic)
                                                           .Set(x => x.Artist, song.Artist)
                                                           .Set(x => x.Album, song.Album)
                                   );
                songs.Add(song);

                return new ResponseMusic
                {
                    codeError = "00",
                    msgError = "Song updated successfully",
                    Songs = songs
                };
            }
            catch(Exception ex)
            {
                return new ResponseMusic
                {
                    codeError = "02",
                    msgError = ex.Message,
                    Songs = songs
                };
            }
        }

        public ResponseMusic Delete(string Id)
        {
            try
            {
                User user = null;
                string _idUser = string.Empty;

                if (_contextAccessor.HttpContext != null)
                {
                    user = (User)_contextAccessor.HttpContext.Items["User"];
                    _idUser = user.Id.ToString();
                }


                var document = MongoContext.Database().GetCollection<Song>("Song");

                var res = OneSong(Id);
                var songs = res.Songs;

                var _id = ObjectId.Parse(Id);
                document.DeleteOne(Builders<Song>.Filter.Eq(x => x.Id, _id));

                return new ResponseMusic
                {
                    codeError = "00",
                    msgError = "Song deleted successfully",
                    Songs = songs
                };
            }
            catch (Exception ex)
            {
                return new ResponseMusic
                {
                    codeError = "02",
                    msgError = ex.Message,
                    Songs = new List<Song>()
            };
            }
        }
    }
}
