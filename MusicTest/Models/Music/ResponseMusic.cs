namespace MusicTest.Models.Music
{
    public class ResponseMusic
    {
        public string codeError { get; set; }
        public string msgError { get; set; }
        public List<Song>? Songs { get; set; }
    }
}
