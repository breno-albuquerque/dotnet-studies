using Microsoft.Data.SqlClient;

namespace SqlDataAccess.Context
{
    static internal class DataContext
    {
        public const string ConnectionString = "Server=localhost,1433;Database=SQL_RESERVATION_SYSTEM;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";

        static public SqlConnection GetConnection() => new SqlConnection(ConnectionString);
    }
}
