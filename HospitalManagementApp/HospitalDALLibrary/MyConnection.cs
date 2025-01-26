using Microsoft.Data.SqlClient;

namespace HospitalDALLibrary
{
    internal class MyConnection
    {
        static SqlConnection? connection;

        public static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                connection = new SqlConnection(@"Server=AS1KHLSL4P3T;TrustServerCertificate=True;Integrated Security=True;Database=HospitalDB;");
            }
            return connection;
        }
    }
}
