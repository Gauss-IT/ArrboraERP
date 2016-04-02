using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using Arrbora.Data.SQLLite.Sql;

namespace Arrbora.Data.SQLLite
{
    public static class DatabaseController
    {
        private const string _dataBaseFileName = "ArrboraDatabase.sqlite";
        private static bool _isConnected;
        private const string _connectionString = "Data Source=" + _dataBaseFileName + ";Version=3;";
        private static SQLiteConnection _connection;


        public static bool IsConnected { get { return _isConnected; } }
        public static string DatabaseFilename { get { return _dataBaseFileName; } }
        public static SQLiteConnection Conncetion { get { return _connection; } }

        public static void CheckDatabase()
        {
            if (!File.Exists(DatabaseFilename))
            {
                SQLiteConnection.CreateFile(DatabaseFilename);
                if (ConnectToDatabase())
                {
                    try
                    {
                        string fileName = @"sql\ArrboraDatabase.sql";

                        // This text is added only once to the file.
                        if (File.Exists(fileName))
                        {
                            var script = File.ReadAllText(fileName);
                            var command = new SQLiteCommand(script, _connection);
                            command.ExecuteNonQuery();

                            _connection.Close();
                        }
                    } catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        public static bool ConnectToDatabase()
        {
             _connection = new SQLiteConnection(_connectionString);
            _isConnected = false;
            try
            {
                _connection.Open();
                if (_connection.State == ConnectionState.Open)
                {
                    _isConnected = true;
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                       
            return _isConnected;
        }
        
    }
}
