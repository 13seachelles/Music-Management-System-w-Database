using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlaylistDataServices;

namespace MusicPlaylistBusinessServices
{
    public class MusicPlaylistService
    {
        public bool MusicPlaylist (string title, string artist)
        {
            MusicDataService dataService = new MusicDataService();
            var result = dataService.GetSongs();

            return result!=null;
        }
    }
}
