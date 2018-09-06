using Npgsql;
using System;

namespace ConsoleApp1
{

    class BancoConnection
    {

        private const String SERVER = "localhost";
        private const String PORT = "5432";
        private const String USER = "postgres";
        private const String PASSWORD = "12345678";
        private const String DATABASE = "filmedb";

        private NpgsqlConnection connection = null;

        public BancoConnection()
        {
            connection = new NpgsqlConnection(
                "Server=" + SERVER + ";" +
                "Port=" + PORT + ";" +
                "User Id=" + USER + ";" +
                "Password=" + PASSWORD + ";" +
                "Database=" + DATABASE + ";");
        }

        public NpgsqlConnection getConnection { get => connection; set => connection = value; }

        public void OpenConnection()
        {
            try
            {
                connection.Open();
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void CloseConnection()
        {
            try
            {
                connection.Close();
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}
