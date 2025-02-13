namespace WebApplication1.Models
{
    public class Playlist_Song
    {
        private int songId = -1;
        private int playlistId = -1;
        private int playlistSongId = -1;

        public int SongId
        {
            get { return this.songId; }
            set { this.songId = value; }
        }

        public int PlaylistId
        {
            get { return this.playlistId; }
            set { this.playlistId = value; }
        }

        public int PlaylistSongId
        {
            get { return this.playlistSongId; }
            set { this.playlistSongId = value; }
        }
        public Playlist_Song() : this(-1, -1, -1)
        {
        }

        public Playlist_Song(int aSongId, int aPlaylistId, int aPlaylistSongId)
        {
            this.SongId = aSongId;
            this.PlaylistId = aPlaylistId;
            this.PlaylistSongId = aPlaylistSongId;
        }
    }
}
