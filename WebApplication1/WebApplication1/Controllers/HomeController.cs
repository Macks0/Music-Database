using ADODB;
using Microsoft.AspNetCore.Mvc;
using System.Data.OleDb;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string artist, int? playlistId, int? songId, string genre)
        {
            DBGateway aGateway = new DBGateway();

            // Fetching data for the dropdowns
            List<Artist> aListOfArtists = aGateway.GetArtist();
            List<Playlist> aListOfPlaylists = aGateway.GetPlaylist();
            List<Song> aListOfSongs = aGateway.GetSong();
            List<string> aListOfGenres = aListOfSongs.Select(s => s.Genre).Distinct().ToList();

            // Get filtered songs if filter criteria are provided
            List<SongViewModel> filteredSongs = FilterSongs(artist, playlistId?.ToString(), songId?.ToString(), genre);

            // Passing data to the view using ViewBag
            ViewBag.ListOfArtists = aListOfArtists;
            ViewBag.ListOfPlaylists = aListOfPlaylists;
            ViewBag.ListOfSongs = aListOfSongs;
            ViewBag.ListOfGenres = aListOfGenres;
            ViewBag.FilteredSongs = filteredSongs; // Passing filtered songs to the view

            return View();
        }

        private List<SongViewModel> FilterSongs(string artistId, string playlistId, string songId, string genre)
        {
            List<SongViewModel> filteredSongs = new List<SongViewModel>();
            string query = @"
                    SELECT s.SongTitle, a.ArtistName, p.PlaylistName, s.Genre
                    FROM Song s, ArtistSong asg, Artist a,  PlaylistSong ps, Playlist p
                    WHERE s.SongID = asg.SongID
                    AND asg.ArtistID = a.ArtistID
                    AND  s.SongID = ps.SongID
                    AND ps.PlaylistID = p.PlaylistID";




            if (!string.IsNullOrEmpty(artistId)) query += " AND a.ArtistId = ?";
            if (!string.IsNullOrEmpty(playlistId)) query += " AND p.PlaylistId = ?";
            if (!string.IsNullOrEmpty(songId)) query += " AND s.SongId = ?";
            if (!string.IsNullOrEmpty(genre)) query += " AND s.Genre = ?";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                // Add parameters to prevent SQL injection
                if (!string.IsNullOrEmpty(artistId)) command.Parameters.AddWithValue("?", artistId);
                if (!string.IsNullOrEmpty(playlistId)) command.Parameters.AddWithValue("?", playlistId);
                if (!string.IsNullOrEmpty(songId)) command.Parameters.AddWithValue("?", songId);
                if (!string.IsNullOrEmpty(genre)) command.Parameters.AddWithValue("?", genre);

                connection.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        filteredSongs.Add(new SongViewModel
                        {
                            SongTitle = reader["SongTitle"].ToString(),
                            ArtistName = reader["ArtistName"].ToString(),
                            PlaylistName = reader["PlaylistName"].ToString(),
                            Genre = reader["Genre"].ToString()
                        });
                    }
                }
            }
            return filteredSongs;
        }




        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Deja Hang\\Downloads\\Database511.accdb;User Id=admin;Password=;";

        // GET: Add
        public ActionResult Add()
        {
            return View();
        }

        // POST: Add
        [HttpPost]
        public ActionResult Add(Song song, string ArtistName)
        {
            // Validate the inputs
            if (string.IsNullOrEmpty(song.SongTitle) || string.IsNullOrEmpty(song.Genre) || string.IsNullOrEmpty(ArtistName))
            {
                ModelState.AddModelError("", "Please fill in all fields.");
                return View();
            }

            // Add artist and retrieve the artist ID (if it doesn't already exist)
            int artistId = GetOrCreateArtist(ArtistName);

            // Insert the song and get the SongId
            int songId = InsertSong(song);

            // Link the artist to the song in the Artist_Song join table
            InsertArtistSongLink(artistId, songId);

            // Redirect back to the index or another page after successful addition
            return RedirectToAction("Index");
        }

        private int GetOrCreateArtist(string artistName)
        {
            // Check if the artist exists
            int artistId = GetArtistIdByName(artistName);

            if (artistId == 0)  // Artist doesn't exist, so we insert a new one
            {
                artistId = InsertArtist(artistName);
            }

            return artistId;
        }

        private int GetArtistIdByName(string artistName)
        {
            int artistId = 0;
            var connection = new Connection();

            try
            {
                connection.Open(connectionString);

                var command = new Command
                {
                    ActiveConnection = connection,
                    CommandText = "SELECT ArtistId FROM Artist WHERE ArtistName = ?",
                    CommandType = CommandTypeEnum.adCmdText
                };

                command.Parameters.Append(command.CreateParameter("ArtistName", DataTypeEnum.adVarWChar, ParameterDirectionEnum.adParamInput, 255, artistName));
                var recordset = command.Execute(out _);

                if (recordset != null && recordset.RecordCount > 0)
                {
                    artistId = Convert.ToInt32(recordset.Fields["ArtistId"].Value);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions, for example:
                Console.WriteLine("Error fetching artist ID: " + ex.Message);
            }
            finally
            {
                if (connection.State == (int)ADODB.ObjectStateEnum.adStateOpen)
                {
                    connection.Close();
                }
            }

            return artistId;
        }

        private int InsertArtist(string artistName)
        {
            int artistId = 0;
            var connection = new Connection();

            try
            {
                connection.Open(connectionString);

                var command = new Command
                {
                    ActiveConnection = connection,
                    CommandText = "INSERT INTO Artist (ArtistName) VALUES (?)",
                    CommandType = CommandTypeEnum.adCmdText
                };

                command.Parameters.Append(command.CreateParameter("ArtistName", DataTypeEnum.adVarWChar, ParameterDirectionEnum.adParamInput, 255, artistName));
                command.Execute(out object recordsAffected);

                // Retrieve the last inserted ArtistId
                command.CommandText = "SELECT @@IDENTITY AS ArtistId";
                var recordset = command.Execute(out _);
                if (recordset != null && recordset.RecordCount > 0)
                {
                    artistId = Convert.ToInt32(recordset.Fields["ArtistId"].Value);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions, for example:
                Console.WriteLine("Error inserting artist: " + ex.Message);
            }
            finally
            {
                if (connection.State == (int)ADODB.ObjectStateEnum.adStateOpen)
                {
                    connection.Close();
                }
            }

            return artistId;
        }


        private int InsertSong(Song song)
        {
            int songId = 0;

            var connection = new Connection();
            try
            {
                connection.Open(connectionString);

                var command = new Command
                {
                    ActiveConnection = connection,
                    CommandText = "INSERT INTO Song (SongTitle, Genre) VALUES (?, ?)",
                    CommandType = CommandTypeEnum.adCmdText
                };

                command.Parameters.Append(command.CreateParameter("SongTitle", DataTypeEnum.adVarWChar, ParameterDirectionEnum.adParamInput, 255, song.SongTitle));
                command.Parameters.Append(command.CreateParameter("Genre", DataTypeEnum.adVarWChar, ParameterDirectionEnum.adParamInput, 50, song.Genre));
                command.Execute(out object recordsAffected);

                // Retrieve the last inserted SongId
                command.CommandText = "SELECT @@IDENTITY AS SongId";
                var recordset = command.Execute(out _);
                if (recordset != null && recordset.RecordCount > 0)
                {
                    songId = Convert.ToInt32(recordset.Fields["SongId"].Value);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine("Error inserting song: " + ex.Message);
            }
            finally
            {
                if (connection.State == (int)ADODB.ObjectStateEnum.adStateOpen)
                {
                    connection.Close();
                }
            }

            return songId;
        }

        private void InsertArtistSongLink(int artistId, int songId)
        {
            var connection = new Connection();
            try
            {
                connection.Open(connectionString);

                var command = new Command
                {
                    ActiveConnection = connection,
                    CommandText = "INSERT INTO Artist_Song (ArtistId, SongId) VALUES (?, ?)",
                    CommandType = CommandTypeEnum.adCmdText
                };

                command.Parameters.Append(command.CreateParameter("ArtistId", DataTypeEnum.adInteger, ParameterDirectionEnum.adParamInput, 0, artistId));
                command.Parameters.Append(command.CreateParameter("SongId", DataTypeEnum.adInteger, ParameterDirectionEnum.adParamInput, 0, songId));
                command.Execute(out object recordsAffected);
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine("Error inserting artist-song link: " + ex.Message);
            }
            finally
            {
                if (connection.State == (int)ADODB.ObjectStateEnum.adStateOpen)
                {
                    connection.Close();
                }
            }
        }

        public bool DeleteArtist(int artistId)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\maxes\source\Database\Database511.accdb;";

            try
            {
                using (var connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Artist WHERE ArtistID = @ArtistID";

                    using (var command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ArtistID", artistId);
                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected > 0; // Returns true if at least one row was deleted
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error deleting artist: {ex.Message}");
                return false;
            }
        }






        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
