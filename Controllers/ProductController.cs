using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyModel;
using WebApiUsingIdentity.DAL.Interface;
using WebApiUsingIdentity.Models;

namespace WebApiUsingIdentity.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public readonly IProduct _Product;
        public ProductController(IProduct Product)
        {
            _Product = Product;
        }

        [HttpGet]
        [Route("GetAllProducts")]

        public async Task<IActionResult> GetAllProducts()
        {
            IEnumerable<Product> obj = null;
            try
            {
                obj = await _Product.GetAllProducts();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(obj);
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct(AddProduct addproduct)
        {
            int result = 0;
            try
            {
                result = await _Product.AddProduct(addproduct);
                if (result == 1)
                {
                    return Ok("Values are inserted");
                }
                else
                {
                    return BadRequest("Something went wrong");
                }
            }
            catch (Exception ex)
            {
                result = 0;
                return BadRequest(ex.Message);
            }
        }
    }
}
