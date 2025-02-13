namespace WebApplication1.Models
{
    public class Artist
    {
        private int artistId = -1;
        private string artistName = "n/a";

        public int ArtistId
        {
            get { return this.artistId; }
            set { this.artistId = value; }
        }

        public string ArtistName
        {
            get { return this.artistName; }
            set { this.artistName = value; }
        }

        public Artist() : this(-1, "n/a")
        {
        }

        public Artist(int aArtistId, string aArtistName)
        {
            this.ArtistId = aArtistId;
            this.ArtistName = aArtistName;
        }
    }
}
