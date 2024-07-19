using MusicPlaylistBusinessServices;
using Microsoft.AspNetCore.Mvc;

namespace MusicPlaylistAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class SongController : Controller
    {
        MusicPlaylistService _musicService;

        public SongController()
        {
            _musicService = new MusicPlaylistService();
        }

        [HttpGet]
        public IEnumerable<MusicPlaylistAPI.Song> GetSongs()
        {
            var activesongs = _musicService.GetSongs();

            List<MusicPlaylistAPI.Song> songs = new List<Song>();

            foreach (var item in activesongs)
            {
                songs.Add(new MusicPlaylistAPI.Song { title = item.title, artist = item.artist });
            }

            return songs;
        }

        [HttpPost]
        public IActionResult AddSong([FromBody] Song song)
        {
            _musicService.AddSong(song.title, song.artist);
            return Ok(new { Message = "Song added successfully" });
        }

        [HttpDelete]
        public IActionResult DeleteSong([FromQuery] string title, [FromQuery] string artist)
        {
            _musicService.DeleteSong(title, artist);
            return Ok(new { Message = "Song deleted successfully" });
        }

        [HttpPatch]
        public IActionResult UpdateSong([FromQuery] string oldTitle, [FromQuery] string oldArtist, [FromBody] Song newSong)
        {
            _musicService.UpdateSong(oldTitle, oldArtist, newSong.title, newSong.artist);
            return Ok(new { Message = "Song updated successfully" });
        }
    }
}
