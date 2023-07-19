using Microsoft.Data.Sqlite;

namespace LibraryApp
{
    internal class DataBase
    {
        static SqliteConnection sqliteConnection = new("Data Source=mainDb.db");

        public static void OpenConnection()
        {
            if (sqliteConnection.State == System.Data.ConnectionState.Closed)
                sqliteConnection.Open();
        }

        public static void CloseConnection()
        {
            if (sqliteConnection.State == System.Data.ConnectionState.Open)
                sqliteConnection.Close();
        }

        public static SqliteConnection GetConnection() => sqliteConnection;
    }
}
