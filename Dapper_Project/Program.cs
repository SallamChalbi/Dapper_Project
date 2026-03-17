using Microsoft.Data.SqlClient;

namespace Dapper_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Server = .; Database = Northwind; Trusted_Connection = True; TrustedServerCertificate = True");
        }
    }
}
