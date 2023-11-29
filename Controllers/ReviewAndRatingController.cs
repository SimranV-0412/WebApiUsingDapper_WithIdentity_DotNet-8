using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiUsingIdentity.DAL.Interface;

namespace WebApiUsingIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewAndRatingController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ReviewAndRatingController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [HttpGet("GetTopRatedProduct_v2")]
        public async Task<IActionResult> GetTopRatedProducts_v2()
        {
            try
            {
                var topRatedProductsResponse = await _productRepository.GetTopRatedProduct_v2();
                if (topRatedProductsResponse.topRatedProducts == null || topRatedProductsResponse.topRatedProducts.Count == 0)
                {
                    return NotFound("No top-rated products found.");
                }

                return Ok(topRatedProductsResponse);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving top-rated products.");
            }
        }


    }

}
