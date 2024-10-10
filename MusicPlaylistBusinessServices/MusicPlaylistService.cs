using MusicPlaylistDataServices;
using MusicPlaylistModels;
using MailKit.Net.Smtp;
using MimeKit;

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
            SendEmailNotification("Song Added to Playlist", $"You've successfully added the song: <strong>{title}</strong> by <strong>{artist}</strong> to your playlist.");
        }

        public void DeleteSong(string title, string artist)
        {
            _dataService.DeleteSong(title, artist);
            SendEmailNotification("Song Deleted to Playlist", $"You've successfully deleted the song: <strong>{title}</strong> by <strong>{artist}</strong> to your playlist.");
        }

        public void UpdateSong(string oldTitle, string oldArtist, string newTitle, string newArtist)
        {
            _dataService.UpdateSong(new Song { title = oldTitle, artist = oldArtist }, new Song { title = newTitle, artist = newArtist });
            SendEmailNotification("Song Updated to Playlist", $"You've successfully updated the song: <strong>{oldTitle}</strong> by <strong>{oldArtist}</strong> to: <strong>{newTitle}</strong> by <strong>{newArtist}</strong>.");
        }

        public static void SendEmailNotification(string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Music Playlist", "noreply@musicplaylist.com"));
            message.To.Add(new MailboxAddress("User", "user@mailkit.com"));
            message.Subject = subject;

            message.Body = new TextPart("html")
            {
                Text = $"<h1>{subject}</h1><p>{body}</p>"
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("sandbox.smtp.mailtrap.io", 2525, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate("f09c8596059c96", "0c173016371323");
                    client.Send(message);
                    Console.WriteLine("Email sent successfully through Mailtrap.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }
    }
}
