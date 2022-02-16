using Microsoft.AspNetCore.Mvc;
using MusicTest.Models.Music;
using MusicTest.Bussines;
using MusicTest.Helpers;

namespace MusicTest.Controllers
{
    [Route("api/music")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMusic _music;

        public MusicController(IConfiguration configuration, IMusic music)
        {
            _configuration = configuration;
            _music = music;
        }

        [Authorize]
        [HttpGet]
        [Route("v1/")]
        public IActionResult All(int page, int perPage)
        {
            var songs = _music.AllSongs(page,perPage);
            return Ok(songs);
        }

        [Authorize]
        [HttpGet("v1/findone/{id}")]
        public IActionResult FindOne(string id)
        {
            var res = _music.OneSong(id);
            return Ok(res);
        }

        [Authorize]
        [HttpPost]
        [Route("v1/create")]
        public IActionResult Create([FromBody] Song song)
        {
            var res = _music.Create(song);
            return Ok(res);
        }

        [Authorize]
        [HttpPut]
        public IActionResult Update([FromBody] Song song)
        {
            var res = _music.Update(song);
            return Ok(res);
        }

        [Authorize]
        [HttpDelete("v1/{id}")]
        public IActionResult Delete(string id)
        {
            var res = _music.Delete(id);
            return Ok(res);
        }
    }
}
