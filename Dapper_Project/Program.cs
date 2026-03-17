using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Dapper_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Server = .; Database = Northwind; Trusted_Connection = True; TrustServerCertificate = True");

            #region Query
            //var result = connection.Query<Product>("Select * From Products");

            ////// or with SP
            ////var result = connection.Query<Product>("SelectAllProducts", commandType: System.Data.CommandType.StoredProcedure);

            //foreach (var item in result)
            //    Console.WriteLine(item.ProductName);
            #endregion

            #region Execute 
            //var result = connection.Execute("Update Products Set ProductName = @ProductName Where ProductId = @ProductId",
            //    new
            //    {
            //        ProductId = 1,
            //        ProductName = "Moca"
            //    });
            ////// or with SP
            ////var result = connection.Execute("UpdateProductNameByProductID",
            ////                        new { ProductId = 1, ProductName = "Tea" },
            ////                        commandType: System.Data.CommandType.StoredProcedure);
            //if (result > 0)
            //    Console.WriteLine("Done");
            //else
            //    Console.WriteLine("Not Done");
            #endregion

            #region CRUD
            ProductManager manager = new ProductManager();

            #region Add
            //Product product = new Product()
            //{
            //    ProductName = "IceMocha",
            //    SupplierId = 1,
            //    CategoryId = 1,
            //    QuantityPerUnit = "20 g",
            //    UnitPrice = 10,
            //    UnitsInStock = 15,
            //    UnitsOnOrder = 10,
            //    ReorderLevel = 20,
            //    Discontinued = true,
            //};
            //if (manager.Add(product))
            //    Console.WriteLine("New Product Added!");
            //else
            //    Console.WriteLine("Adding Product Failed!!");
            #endregion

            #region Read
            var Result1 = manager.GetAll().Count();
            Console.WriteLine($"Number of Product = {Result1}");
            #endregion
            #endregion
        }
    }
}
