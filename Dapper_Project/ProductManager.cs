using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Project
{
    public class ProductManager : IManager<Product>
    {
        SqlConnection connection = new SqlConnection("Server = .; Database = Northwind; Trusted_Connection = True; TrustServerCertificate = True");
        public bool Add(Product item)
        {
            try
            {
                return connection.Execute("Insert Into Products" +
                      "(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock," +
                      " UnitsOnOrder, ReorderLevel, Discontinued) VALUES (@ProductName,@SupplierID,@CategoryID, " +
                      "@QuantityPerUnit,@UnitPrice,@UnitsInStock,@UnitsOnOrder,@ReorderLevel,@Discontinued)", item) > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
            => connection.Execute("DeleteProductByID", new { ProductId = id }, commandType: System.Data.CommandType.StoredProcedure) > 0;

        public List<Product> GetAll()
            => connection.Query<Product>("SelectAllProducts",commandType:System.Data.CommandType.StoredProcedure).ToList();

        public Product? GetById(int id)
            => connection.QueryFirstOrDefault<Product>("Select * From Products Where ProductId = @ProductId", new { ProductId = id });

        public bool Update(Product item)
        {
            return connection.Execute("Update Products Set " +
                "ProductName=@ProductName, SupplierId=@SupplierId, CategoryId=@CategoryId, " +
                "QuantityPerUnit=@QuantityPerUnit, UnitPrice=@UnitPrice, UnitsInStock=@UnitsInStock, " +
                "UnitsOnOrder=@UnitsOnOrder, ReorderLevel=@ReorderLevel, Discontinued=@Discontinued " +
                "Where ProductId=@ProductId", 
                new
                {
                    item.ProductId,
                    item.ProductName,
                    item.SupplierId,
                    item.CategoryId,
                    item.QuantityPerUnit,
                    item.UnitPrice,
                    item.UnitsInStock,
                    item.UnitsOnOrder,
                    item.ReorderLevel,
                    item.Discontinued
                }) > 0;
        }
    }
}
