using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using WebApiUsingIdentity.DAL.Interface;
using WebApiUsingIdentity.Models;

namespace WebApiUsingIdentity.DAL
{
    public class ContactUsRepo : IContactUs
    {
        private readonly string _connectionString;
        private readonly IConfiguration _config;

        public ContactUsRepo(IConfiguration configuration)
        {
            _config = configuration;
            _connectionString = _config.GetConnectionString("Con");
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
