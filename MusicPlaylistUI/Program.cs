using MusicPlaylistModels;
using MusicPlaylistBusinessServices;
using MusicPlaylistDataServices;

namespace MusicPlaylistUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(":¨ ·.· ¨:\r\n `· . ·` ");
            Console.WriteLine("Welcome to Your Playlist! Enter your favorite songs to be added in your playlist! ˚v˚ ");
            Console.WriteLine(" ");

            //SqlDbData.Connect();

            SqlDbData dataService = new SqlDbData();
            int songIndex = 1;

            while (true)
            {
                Console.WriteLine(":¨ ·.· ¨: ");
                Console.WriteLine("Options: ");
                Console.WriteLine("1. Add a song");
                Console.WriteLine("2. Delete a song");
                Console.WriteLine("3. View playlist");
                Console.WriteLine("4. Update a song");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    Console.WriteLine(" ");
                    Console.Write("Enter song title: ");
                    string title = Console.ReadLine();

                    Console.Write("Enter artist name: ");
                    string artist = Console.ReadLine();

                    dataService.AddSong(new Song { title = title, artist = artist });

                    Console.WriteLine($"Added Song: {title} - {artist}");
                }
                else if (option == "2")
                {
                    Console.WriteLine(" ");
                    Console.Write("Enter song title to delete (or 'b' to back): ");
                    string title = Console.ReadLine();
                    if (title.ToLower() == "b")
                    {
                        continue;
                    }

                    Console.Write("Enter artist name to delete (or 'b' to back): ");
                    string artist = Console.ReadLine();
                    if (artist.ToLower() == "b")
                    {
                        continue;
                    }

                    dataService.DeleteSong(title, artist);

                    Console.WriteLine($"Deleted Song: {title} - {artist}");
                }
                else if (option == "3")
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Your Playlist:");
                    foreach (var addedSong in dataService.GetSongs())
                    {
                        Console.WriteLine($"{songIndex++}: {addedSong.title} - {addedSong.artist}");
                    }
                    songIndex = 1;
                }
                else if (option == "4")
                {
                    Console.WriteLine(" ");
                    Console.Write("Enter the current song title to update (or 'b' to back): ");
                    string oldTitle = Console.ReadLine();
                    if (oldTitle.ToLower() == "b")
                    {
                        continue;
                    }

                    Console.Write("Enter the current artist name to update (or 'b' to back): ");
                    string oldArtist = Console.ReadLine();
                    if (oldArtist.ToLower() == "b")
                    {
                        continue;
                    }

                    Console.Write("Enter the new song title: ");
                    string newTitle = Console.ReadLine();

                    Console.Write("Enter the new artist name: ");
                    string newArtist = Console.ReadLine();

                    dataService.UpdateSong(new Song { title = oldTitle, artist = oldArtist }, new Song { title = newTitle, artist = newArtist });

                    Console.WriteLine($"Updated Song: {oldTitle} - {oldArtist} to {newTitle} - {newArtist}");
                }
                else if (option == "5")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option, please try again.");
                }

                Console.WriteLine(" ");
            }
        }
        
    }
    
}
              
