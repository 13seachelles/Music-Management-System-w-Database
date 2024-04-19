using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlaylistModels;

namespace MusicPlaylistDataServices
{
    public class MusicDataService
    {
        List<UserAcc> dummyUsers = new List<UserAcc> ();

        public MusicDataService()
        {
            CreateDummyUser();
        }

        private void CreateDummyUser()
        {
            UserAcc defaultuser = new UserAcc
            {
                username = "Chelle",
                password = "qtXD"
            };

            UserAcc defaultuser2 = new UserAcc
            {
                username = "Taylor",
                password = "imtheproblem,itsme"
            };

            dummyUsers.Add(defaultuser);
            dummyUsers.Add(defaultuser2);
        }
        public UserAcc GetUser(string username)
        {
            UserAcc foundUser = new UserAcc();

            foreach (var dummy in dummyUsers)
            {
                if (username == dummy.username)
                {
                    foundUser = dummy;
                }
            }

            return foundUser;
        }

        List<Song> songs = new List<Song>();
        public void AddSong(Song song)
        {
            songs.Add (song);
        }
        public List<Song> GetSongs()
        {
            return songs;
        }
    }
}
