using Dapper;
using Microsoft.Data.SqlClient;
using System;
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

        public async Task<TopRatedProductsResponse> GetTopRatedProduct_v2()
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

                    var url = _config["WebSiteURL:LocalUrl"];
                    var productList = products.AsList();

                    foreach (var item in productList)
                    {
                        item.ProductImageURL = $"{url}{item.ProductImageURL}";
                    }

                    return new TopRatedProductsResponse
                    {
                        topRatedProducts = productList
                    };
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
