using MusicPlaylistModels;
using MusicPlaylistBusinessServices;
using MusicPlaylistDataServices;

namespace MusicPlaylistUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            MusicPlaylistService musicService = new MusicPlaylistService();
            bool result = musicService.MusicPlaylist(username,password);

            if (result)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Welcome to Your Playlist! Enter your favorite songs to be added in your playlist! ^_^ ");
                Console.WriteLine(" ");
            }
            else
            {
                Console.WriteLine("ERROR: User not found.");
                return;
            }

            MusicDataService dataService = new MusicDataService();
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

                dataService.AddSong(new Song { title = title, artist = artist });

                Console.WriteLine($"Added Song: {title} - {artist}");
                Console.WriteLine(" ");
                Console.WriteLine("Your Playlist:");

                foreach (var addedSong in dataService.GetSongs())
                {
                    Console.WriteLine($"{songIndex++}: {addedSong.title} - {addedSong.artist}");
                }
                songIndex = 1;
                Console.WriteLine(" ");
                }
        }
    }
}
              
