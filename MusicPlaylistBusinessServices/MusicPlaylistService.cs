using MusicPlaylistDataServices;

namespace MusicPlaylistBusinessServices
{
    public class MusicPlaylistService
    {
        public bool Playlist(string title, string artist)
        {
            SqlDbData dataService = new SqlDbData();
            var result = dataService.GetSongs();

            return result != null;
        }
    }
}
