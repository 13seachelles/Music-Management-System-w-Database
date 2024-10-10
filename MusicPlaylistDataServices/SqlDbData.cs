using MusicPlaylistModels;
using System.Data.SqlClient;

namespace MusicPlaylistDataServices
{
    public class SqlDbData
    {
        static string connectionString
            = "Data Source =LAPTOP-QQEBTG3V\\SQLEXPRESS; Initial Catalog = AccountManagement; Integrated Security = True;";
            //= "Server = tcp:20.205.142.49,1433;Database= AccountManagement;User Id= sa;Password= rachelleiskolar43_";

        public List<Song> GetSongs()
        {
            List<Song> songs = new List<Song>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {

                string selectStatement = "SELECT title, artist FROM songs";
                SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

                 sqlConnection.Open();

                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Song song = new Song()
                        {
                            title = reader["title"].ToString(),
                            artist = reader["artist"].ToString()
                        };
                        songs.Add(song);
                    }
                }
            }
            return songs;

        }

        public void AddSong(Song song)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {

                string insertStatement = "INSERT INTO songs VALUES (@title, @artist)";
                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

                insertCommand.Parameters.AddWithValue("@title", song.title);
                insertCommand.Parameters.AddWithValue("@artist", song.artist);

                sqlConnection.Open();
                insertCommand.ExecuteNonQuery();

            }
        }

        public void DeleteSong(string title, string artist)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string deleteStatement = "DELETE FROM songs WHERE title = @title AND artist = @artist";
                SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);

                deleteCommand.Parameters.AddWithValue("@title", title);
                deleteCommand.Parameters.AddWithValue("@artist", artist);

                sqlConnection.Open();
                deleteCommand.ExecuteNonQuery();
            }
        }

        public void UpdateSong(Song oldSong, Song newSong)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string updateStatement = "UPDATE songs SET title = @newTitle, artist = @newArtist WHERE title = @oldTitle AND artist = @oldArtist";
                SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

                updateCommand.Parameters.AddWithValue("@newTitle", newSong.title);
                updateCommand.Parameters.AddWithValue("@newArtist", newSong.artist);
                updateCommand.Parameters.AddWithValue("@oldTitle", oldSong.title);
                updateCommand.Parameters.AddWithValue("@oldArtist", oldSong.artist);

                sqlConnection.Open();
                updateCommand.ExecuteNonQuery();
            }
        }
    }
}
