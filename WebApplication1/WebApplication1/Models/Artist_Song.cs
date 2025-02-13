namespace WebApplication1.Models
{
    public class Artist_Song
    {
        private int artistSongId = -1;
        private int songId = -1;
        private int artistId = -1;

        public int ArtistSongId
        {
            get { return this.artistSongId; }
            set { this.artistSongId = value; }
        }

        public int SongId
        {
            get { return this.songId; }
            set { this.songId = value; }
        }

        public int ArtistId
        {
            get { return this.artistId; }
            set { this.artistId = value; }
        }

        public Artist_Song() : this(-1, -1, -1)
        {
        }

        public Artist_Song (int aSongId, int aArtistId, int aArtistSongId)
        {
            this.SongId = aSongId;
            this.ArtistId = aArtistId;
            this.ArtistSongId = aArtistSongId;
        }
    }
}
