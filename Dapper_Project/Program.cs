using Dapper;
using Microsoft.Data.SqlClient;

namespace Dapper_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sc = new SqlConnection("Server =.;Database=Northwind;Trusted_Connection = True; TrustServerCertificate = True");

            #region CRUD
            #region Query
            #region Read 
            var result = sc.Query<Product>("Select * From Products");

            //// or by SP
            //var result = sc.Query<Product>("SelectAllProducts", commandType: System.Data.CommandType.StoredProcedure);

            foreach (var item in result)
                Console.WriteLine(item.ProductName); 
            #endregion
            #endregion
            #endregion
        }
    }
}
