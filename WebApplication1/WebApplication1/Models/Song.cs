namespace WebApplication1.Models
{
    public class Song
    {
        private int songId = -1;
        private string songTitle = "n/a";
        private string genre = "n/a";

        public int SongId
        {
            get { return this.songId; }
            set { this.songId = value; }
        }

        public string SongTitle
        {
            get { return this.songTitle; }
            set { this.songTitle = value; }
        }
        public string Genre
        {
            get { return this.genre; }
            set { this.genre = value; }
        }
        public Song() : this(-1, "n/a", "n/a")
        {
        }

        public Song(int aSongId, string aSongTitle, string aGenre)
        {
            this.SongId = aSongId;
            this.SongTitle = aSongTitle;
            this.Genre = aGenre;
        }
    }
}
