namespace WebApplication1.Models
{
    public class Playlist
    {
        private int playlistId = -1;
        private string playlistName = "n/a";

        public int PlaylistId
        {
            get { return this.playlistId; }
            set { this.playlistId = value; }
        }

        public string PlaylistName
        {
            get { return this.playlistName; }
            set { this.playlistName = value; }
        }


        public Playlist() : this(-1, "n/a")
        {
        }

        public Playlist(int aPlaylistId, string aPlaylistName)
        {
            this.PlaylistId = aPlaylistId;
            this.PlaylistName = aPlaylistName;
        }
    }
}
