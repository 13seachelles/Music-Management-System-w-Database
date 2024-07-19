using MusicPlaylistDataServices;
using MusicPlaylistModels;

namespace MusicPlaylistBusinessServices
{
    public class MusicPlaylistService
    {
        private readonly SqlDbData _dataService;

        public MusicPlaylistService()
        {
            _dataService = new SqlDbData();
        }

        public List<Song> GetSongs()
        {
            return _dataService.GetSongs();
        }

        public void AddSong(string title, string artist)
        {
            _dataService.AddSong(new Song { title = title, artist = artist });
        }

        public void DeleteSong(string title, string artist)
        {
            _dataService.DeleteSong(title, artist);
        }

        public void UpdateSong(string oldTitle, string oldArtist, string newTitle, string newArtist)
        {
            _dataService.UpdateSong(new Song { title = oldTitle, artist = oldArtist }, new Song { title = newTitle, artist = newArtist });
        }
    }
}
