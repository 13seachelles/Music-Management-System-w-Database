using MusicPlaylistModels;

namespace MusicPlaylistDataServices
{
    public class MusicDataService
    {
        List<Song> songs = new List<Song>();
        public void AddSong(Song song)
        {
            songs.Add(song);
        }
        public List<Song> GetSongs()
        {
            return songs;
        }
    }
}
