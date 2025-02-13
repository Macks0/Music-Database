using System;
using System.Collections.Generic;
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

    }
}
