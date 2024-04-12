using MusicPlaylistModels;
using MusicPlaylistBusinessServices;
using MusicPlaylistDataServices;

namespace MusicPlaylistUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            MusicDataService playlist = new MusicDataService();
            int songIndex = 1;

            while (true)
            {
                Console.Write("Enter song title (or 'e' to exit): ");
                string title = Console.ReadLine();
                if (title.ToLower() == "e")
                {
                    break;
                }

                Console.Write("Enter artist name: ");
                string artist = Console.ReadLine();

                MusicPlaylistService musicPlaylist = new MusicPlaylistService();
                bool result = musicPlaylist.MusicPlaylist(title, artist);

                if(result)
                {
                    Song song = new Song { title = title, artist = artist };
                    playlist.AddSong(song);
                    Console.WriteLine($"Added Song: " + title + "-" + artist);

                    Console.WriteLine(" ");
                    Console.WriteLine("Welcome to Your Playlist! ");

                    foreach(var AddedSong in playlist.GetSongs())
                    {
                        Console.WriteLine($"{songIndex++}: " + AddedSong.title + "-" + AddedSong.artist);
                    }
                    songIndex = 1;
                    Console.WriteLine(" ");
                }
            }
        }
    }
}
