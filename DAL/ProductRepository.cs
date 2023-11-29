using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using WebApiUsingIdentity.DAL.Interface;
using WebApiUsingIdentity.Models;

namespace WebApiUsingIdentity.DAL
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
                    var offers = await GetOffers();
                    var promoCodes = await GetPromoCodes();

                    return new TopRatedProductsResponse
                    {
                        topRatedProducts = productList,
                        offers = offers,
                        promoCodes = promoCodes
                    };
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Offer>> GetOffers()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var offers = await connection.QueryAsync<Offer>("GetOffers", commandType: CommandType.StoredProcedure);

                    var url = _config["WebSiteURL:LocalUrl"];
                    foreach (var item in offers)
                    {
                        item.OfferImageURL = $"{url}{item.OfferImageURL}";
                    }

                    return offers.AsList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PromoCodeDetails>> GetPromoCodes()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var promoCodes = await connection.QueryAsync<PromoCodeDetails>("GetPromoCodes", commandType: CommandType.StoredProcedure);

                    var url = _config["WebSiteURL:LocalUrl"];
                    foreach (var item in promoCodes)
                    {
                        item.ImageUrl = $"{url}{item.ImageUrl}";
                    }
                    return promoCodes.AsList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
