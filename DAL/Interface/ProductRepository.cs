using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using WebApiUsingIdentity.Models;

namespace WebApiUsingIdentity.DAL.Interface
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _config;

        public ProductRepository(IConfiguration configuration)
        {
            _config = configuration;
            _connectionString = _config.GetConnectionString("GoPure");
        }
        //public async Task<List<Product_v2>> GetTopRatedProduct_v2(string userId)
        //{
        //    try
        //    {
        //        using (var connection = new SqlConnection(_connectionString))
        //        {
        //            await connection.OpenAsync();

        //            var parameters = new { UserId = userId };
        //            var products = await connection.QueryAsync<Product_v2>(
        //                "GetTopRatedProduct_v2",
        //                parameters,
        //                commandType: CommandType.StoredProcedure
        //            );

        //            return products.AsList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
        public async Task<List<Product_v2>> GetTopRatedProduct_v2()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var products = await connection.QueryAsync<Product_v2>(
                        "GetTopRatedProduct_v2",
                        commandType: CommandType.StoredProcedure
                    );

                    return products.AsList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
