using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using WebApiUsingIdentity.DAL.Interface;
using WebApiUsingIdentity.Models;

namespace WebApiUsingIdentity.DAL
{
    public class ProductRepo : IProduct
    {
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        public ProductRepo(IConfiguration configuration)
        {
            _config = configuration;
            _connectionString = _config.GetConnectionString("Con");
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            IEnumerable<Product> obj = null;
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "GetAllProducts";
                    obj = await connection.QueryAsync<Product>(procedure, null, commandType: CommandType.StoredProcedure);
                }
                return obj.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<int> AddProduct(AddProduct addproduct)
        {
            int result = 0;
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "AddProduct";
                    var values = new
                    {
                        //Id = addproduct.ID,
                        Name = addproduct.Name,
                        Description = addproduct.Description,
                        Price = addproduct.Price,
                    };
                    //result = connection.QueryFirst<int>(procedure, values, commandType: CommandType.StoredProcedure);
                    result = await connection.QueryFirstOrDefaultAsync<int>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<int> AddContactUs(ContactUs contactUs)
        {
            int result = 0;
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "InsertContactUs";
                    var values = new
                    {
                        Name = contactUs.Name,
                        Email = contactUs.Email,
                        Message = contactUs.Message,
                    };
                    result = await connection.QueryFirstOrDefaultAsync<int>(procedure, values, commandType: CommandType.StoredProcedure);
                }
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
