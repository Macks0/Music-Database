using System;
using System.Collections.Generic;
using System.Data.OleDb;
using ADODB;

namespace WebApplication1.Models
{
    public class DBGateway
    {
        public List<Playlist> GetPlaylist()
        {
            List<Playlist> playlists = new List<Playlist>();

            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Deja Hang\\Downloads\\Database511.accdb;User Id=admin;Password=;";

            // Ado Objects
            Connection aConnection = new Connection();
            Command aCommand = new Command();
            Recordset aRecordset = null;


            try
            {
                // Open the connection 
                aConnection.Open(connectionString);

                // Configure the Command
                aCommand.ActiveConnection = aConnection; //Setting it to active connection
                aCommand.CommandText = "select PlaylistID, PlaylistName from playlist"; //Sending sql statement
                aCommand.CommandType = CommandTypeEnum.adCmdText; // Telling it that it is a sql statement

                // Grabbing data
                aRecordset = new ADODB.Recordset();
                aRecordset.CursorType = CursorTypeEnum.adOpenStatic;
                aRecordset.CursorLocation = CursorLocationEnum.adUseClient;

                aRecordset.Open(
                    aCommand.CommandText,
                    aConnection,
                    CursorTypeEnum.adOpenStatic,
                    LockTypeEnum.adLockReadOnly,
                    (int)CommandTypeEnum.adCmdText

                    );

                while (!aRecordset.EOF)
                {
                    Playlist playlist = new Playlist();
                    playlist.PlaylistId = Convert.ToInt32(aRecordset.Fields["PlaylistID"].Value);
                    playlist.PlaylistName = aRecordset.Fields["PlaylistName"].Value.ToString();

                    playlists.Add(playlist);
                    aRecordset.MoveNext();



                }

            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            finally
            {
                if (aRecordset != null && aRecordset.State == (int)ADODB.ObjectStateEnum.adStateOpen)
                {
                    aRecordset.Close();
                }
                if (aConnection.State == (int)ADODB.ObjectStateEnum.adStateOpen)
                {
                    aConnection.Close();
                }
            }

            return playlists;

        }

        public List<Artist> GetArtist()
        {
            List<Artist> artists = new List<Artist>();

            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Deja Hang\\Downloads\\Database511.accdb;User Id=admin;Password=;";

            // Ado Objects
            Connection aConnection = new Connection();
            Command aCommand = new Command();
            Recordset aRecordset = null;


            try
            {
                // Open the connection 
                aConnection.Open(connectionString);

                // Configure the Command
                aCommand.ActiveConnection = aConnection; //Setting it to active connection
                aCommand.CommandText = "select ArtistID, ArtistName from Artist"; //Sending sql statement
                aCommand.CommandType = CommandTypeEnum.adCmdText; // Telling it that it is a sql statement

                // Grabbing data
                aRecordset = new ADODB.Recordset();
                aRecordset.CursorType = CursorTypeEnum.adOpenStatic;
                aRecordset.CursorLocation = CursorLocationEnum.adUseClient;

                aRecordset.Open(
                    aCommand.CommandText,
                    aConnection,
                    CursorTypeEnum.adOpenStatic,
                    LockTypeEnum.adLockReadOnly,
                    (int)CommandTypeEnum.adCmdText

                    );

                while (!aRecordset.EOF)
                {
                    Artist artist = new Artist();
                    artist.ArtistId = Convert.ToInt32(aRecordset.Fields["ArtistID"].Value);
                    artist.ArtistName = aRecordset.Fields["ArtistName"].Value.ToString();

                    artists.Add(artist);
                    aRecordset.MoveNext();



                }

            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            finally
            {
                if (aRecordset != null && aRecordset.State == (int)ADODB.ObjectStateEnum.adStateOpen)
                {
                    aRecordset.Close();
                }
                if (aConnection.State == (int)ADODB.ObjectStateEnum.adStateOpen)
                {
                    aConnection.Close();
                }
            }

            return artists;

        }

        public List<Artist_Song> GetArtistSong()
        {
            List<Artist_Song> artistssong = new List<Artist_Song>();

            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Deja Hang\\Downloads\\Database511.accdb;User Id=admin;Password=;";

            // Ado Objects
            Connection aConnection = new Connection();
            Command aCommand = new Command();
            Recordset aRecordset = null;


            try
            {
                // Open the connection 
                aConnection.Open(connectionString);

                // Configure the Command
                aCommand.ActiveConnection = aConnection; //Setting it to active connection
                aCommand.CommandText = "select ArtistId, SongId from Artist_Song"; //Sending sql statement
                aCommand.CommandType = CommandTypeEnum.adCmdText; // Telling it that it is a sql statement

                // Grabbing data
                aRecordset = new ADODB.Recordset();
                aRecordset.CursorType = CursorTypeEnum.adOpenStatic;
                aRecordset.CursorLocation = CursorLocationEnum.adUseClient;

                aRecordset.Open(
                    aCommand.CommandText,
                    aConnection,
                    CursorTypeEnum.adOpenStatic,
                    LockTypeEnum.adLockReadOnly,
                    (int)CommandTypeEnum.adCmdText

                    );

                while (!aRecordset.EOF)
                {
                    Artist_Song artistsong = new Artist_Song();
                    artistsong.ArtistId = Convert.ToInt32(aRecordset.Fields["ArtistID"].Value);
                    artistsong.SongId = Convert.ToInt32(aRecordset.Fields["SongID"].Value);

                    artistssong.Add(artistsong);
                    aRecordset.MoveNext();



                }

            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            finally
            {
                if (aRecordset != null && aRecordset.State == (int)ADODB.ObjectStateEnum.adStateOpen)
                {
                    aRecordset.Close();
                }
                if (aConnection.State == (int)ADODB.ObjectStateEnum.adStateOpen)
                {
                    aConnection.Close();
                }
            }

            return artistssong;

        }

        public List<Song> GetSong()
        {
            List<Song> songs = new List<Song>();

            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Deja Hang\\Downloads\\Database511.accdb;User Id=admin;Password=;";

            // Ado Objects
            Connection aConnection = new Connection();
            Command aCommand = new Command();
            Recordset aRecordset = null;

            try
            {
                // Open the connection 
                aConnection.Open(connectionString);

                // Configure the Command
                aCommand.ActiveConnection = aConnection; // Setting it to active connection
                aCommand.CommandText = "SELECT SongId, SongTitle, Genre FROM Song"; // Include Genre in the query
                aCommand.CommandType = CommandTypeEnum.adCmdText; // SQL command

                // Grabbing data
                aRecordset = new ADODB.Recordset();
                aRecordset.CursorType = CursorTypeEnum.adOpenStatic;
                aRecordset.CursorLocation = CursorLocationEnum.adUseClient;

                aRecordset.Open(
                    aCommand.CommandText,
                    aConnection,
                    CursorTypeEnum.adOpenStatic,
                    LockTypeEnum.adLockReadOnly,
                    (int)CommandTypeEnum.adCmdText
                );

                while (!aRecordset.EOF)
                {
                    Song song = new Song();
                    song.SongId = Convert.ToInt32(aRecordset.Fields["SongId"].Value);
                    song.SongTitle = aRecordset.Fields["SongTitle"].Value.ToString();
                    song.Genre = aRecordset.Fields["Genre"].Value.ToString();  // Retrieve Genre

                    songs.Add(song);
                    aRecordset.MoveNext();
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            finally
            {
                if (aRecordset != null && aRecordset.State == (int)ADODB.ObjectStateEnum.adStateOpen)
                {
                    aRecordset.Close();
                }
                if (aConnection.State == (int)ADODB.ObjectStateEnum.adStateOpen)
                {
                    aConnection.Close();
                }
            }

            return songs;
        }

        // Add this line at the top of the DBGateway class
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Deja Hang\\Downloads\\Database511.accdb;User Id=admin;Password=;";


        public bool DeleteSongFromPlaylist(int songId, int playlistId)
        {
            string query = "DELETE FROM Playlist_Song WHERE SongID = @SongID AND PlaylistID = @PlaylistID";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SongID", songId);
                command.Parameters.AddWithValue("@PlaylistID", playlistId);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;  // Returns true if the deletion is successful
            }
        }



        public bool DeleteArtistSongLink(int songId)
        {
            string query = "DELETE FROM ArtistSong WHERE SongID = @SongID";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SongID", songId);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }


        // This method deletes the song from both the playlist and the Song table.
        public bool DeleteSong(int songId)
        {
            string query = "DELETE FROM Song WHERE SongID = @SongID";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SongID", songId);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;  // Returns true if the deletion is successful
            }
        }




        public bool DeleteArtistIfNoSongs(int artistId)
        {
            // Check if the artist has any songs left in the Artist_Song table
            string checkQuery = "SELECT COUNT(*) FROM Artist_Song WHERE ArtistID = @ArtistID";
            int songCount = 0;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(checkQuery, connection))
            {
                command.Parameters.AddWithValue("@ArtistID", artistId);

                connection.Open();
                songCount = Convert.ToInt32(command.ExecuteScalar());
            }

            if (songCount == 0)  // If no songs are left, delete the artist
            {
                string deleteQuery = "DELETE FROM Artist WHERE ArtistID = @ArtistID";
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                using (OleDbCommand command = new OleDbCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@ArtistID", artistId);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }

            return false;  // Artist has songs left, so not deleted
        }





        public Song GetSongById(int songId)
        {
            Song song = null;
            string query = "SELECT SongId, SongTitle, Genre FROM Song WHERE SongId = ?";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("?", songId);

                connection.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        song = new Song
                        {
                            SongId = Convert.ToInt32(reader["SongId"]),
                            SongTitle = reader["SongTitle"].ToString(),
                            Genre = reader["Genre"].ToString()
                        };
                    }
                }
            }

            return song;
        }

        public int GetArtistIdBySongId(int songId)
        {
            string query = "SELECT ArtistID FROM Artist_Song WHERE SongID = @SongID";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SongID", songId);

                connection.Open();
                object result = command.ExecuteScalar();  // ExecuteScalar returns the first column of the first row

                // If a result is found, return the ArtistID; otherwise, return 0 (or handle as needed)
                return result != DBNull.Value ? Convert.ToInt32(result) : 0;
            }
        }


        public string GetArtistNameBySongId(int songId)
        {
            string artistName = string.Empty;
            string query = @"
                SELECT a.ArtistName
                FROM Artist a
                INNER JOIN ArtistSong asg ON a.ArtistId = asg.ArtistId
                WHERE asg.SongId = ?";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("?", songId);

                connection.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        artistName = reader["ArtistName"].ToString();
                    }
                }
            }

            return artistName;
        }


        public string GetPlaylistNameBySongId(int songId)
        {
            string playlistName = string.Empty;
            string query = @"
                SELECT p.PlaylistName
                FROM Playlist p
                INNER JOIN PlaylistSong ps ON p.PlaylistId = ps.PlaylistId
                WHERE ps.SongId = ?";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("?", songId);

                connection.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        playlistName = reader["PlaylistName"].ToString();
                    }
                }
            }

            return playlistName;
        }

        public int GetArtistIdByName(string artistName)
        {
            int artistId = 0;
            string query = "SELECT ArtistId FROM Artist WHERE ArtistName = ?";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("?", artistName);

                connection.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        artistId = Convert.ToInt32(reader["ArtistId"]);
                    }
                }
            }

            return artistId;
        }

        public int InsertArtist(string artistName)
        {
            int artistId = 0;
            string query = "INSERT INTO Artist (ArtistName) VALUES (?)";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("?", artistName);

                connection.Open();
                command.ExecuteNonQuery();

                // Retrieve the last inserted ArtistId
                command.CommandText = "SELECT @@IDENTITY AS ArtistId";
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        artistId = Convert.ToInt32(reader["ArtistId"]);
                    }
                }
            }

            return artistId;
        }
        public void UpdateSong(Song song)
        {
            string query = @"
                UPDATE Song
                SET SongTitle = ?, Genre = ?
                WHERE SongId = ?";  // Update the Song table based on the SongId

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("?", song.SongTitle);  // New SongTitle
                command.Parameters.AddWithValue("?", song.Genre);      // New Genre
                command.Parameters.AddWithValue("?", song.SongId);     // The SongId to identify the row

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateArtistSong(int songId, int artistId)
        {
            string query = @"
                UPDATE ArtistSong
                SET ArtistId = ?
                WHERE SongId = ? AND ArtistId <> ?";  // Use <> for inequality in OLE DB (Access)

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("?", artistId);  // New ArtistId to set
                command.Parameters.AddWithValue("?", songId);    // The SongId to identify the row
                command.Parameters.AddWithValue("?", artistId);  // Ensures we're not updating if ArtistId is the same

                connection.Open();
                command.ExecuteNonQuery();
            }
        }



        public void UpdatePlaylistSong(int songId, int playlistId)
        {
            string query = @"
                UPDATE PlaylistSong
                SET PlaylistId = ?
                WHERE SongId = ? AND PlaylistId <> ?";  // Ensure we only update the record where the PlaylistId is different

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("?", playlistId);  // New PlaylistId to set
                command.Parameters.AddWithValue("?", songId);  // The SongId to identify the row
                command.Parameters.AddWithValue("?", playlistId);  // Ensures we're not updating if PlaylistId is the same

                connection.Open();
                command.ExecuteNonQuery();
            }
        }



    public int GetPlaylistIdByName(string playlistName)
        {
            int playlistId = 0;
            string query = "SELECT PlaylistId FROM Playlist WHERE PlaylistName = ?";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("?", playlistName);

                connection.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        playlistId = Convert.ToInt32(reader["PlaylistId"]);
                    }
                }
            }

            return playlistId;
        }

        public int GetOrCreateArtist(string artistName)
        {
            int artistId = GetArtistIdByName(artistName);

            if (artistId == 0)
            {
                artistId = InsertArtist(artistName);
            }

            return artistId;
        }



    }
}
