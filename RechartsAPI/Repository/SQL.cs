using Microsoft.Data.SqlClient;

namespace RechartsAPI.Repository
{
    public class SQL
    {
        private static SqlConnection? _connection;
        public static SqlConnection Connection()
        {
            if (_connection == null)
                _connection = new SqlConnection(Settings.SQLConnectionString);

            return _connection;
        }
    }
}
