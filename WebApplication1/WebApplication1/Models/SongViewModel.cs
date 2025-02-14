namespace WebApplication1.Models
{
    public class SongViewModel
    {
            public string SongTitle { get; set; }
            public string ArtistName { get; set; }
            public string PlaylistName { get; set; }
            public string Genre { get; set; }

            public int SongId { get; set; }
            public int ArtistId { get; set; }
            public int PlaylistId { get; set; }
    }
}
