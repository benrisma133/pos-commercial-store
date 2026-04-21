using Microsoft.Data.Sqlite;

namespace Repository.Factory
{
    public static class DbHelper
    {
        private static readonly string _cs = clsDataAccessSettings.ConnectionString;

        public static SqliteConnection OpenConnection()
        {
            SqliteConnection con = new SqliteConnection(_cs);
            con.Open();
            using (SqliteCommand cmd = new SqliteCommand("PRAGMA foreign_keys = ON;", con))
            {
                cmd.ExecuteNonQuery();
            }
            return con;
        }
    }
}