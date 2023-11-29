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

        //[HttpGet("GetTopRatedProduct_v2")]
        //public async Task<IActionResult> GetTopRatedProducts_v2(string userId)
        //{
        //    try
        //    {
        //        var topRatedProducts = await _productRepository.GetTopRatedProduct_v2(userId);
        //        if (topRatedProducts == null || topRatedProducts.Count == 0)
        //        {
        //            return NotFound("No top-rated products found.");
        //        }

        //        return Ok(topRatedProducts);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception or handle it as needed
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving top-rated products.");
        //    }
        //}
        [HttpGet("GetTopRatedProduct_v2")]
        public async Task<IActionResult> GetTopRatedProducts_v2()
        {
            try
            {
                var topRatedProducts = await _productRepository.GetTopRatedProduct_v2();
                if (topRatedProducts == null || topRatedProducts.Count == 0)
                {
                    return NotFound("No top-rated products found.");
                }

                return Ok(topRatedProducts);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving top-rated products.");
            }
        }


    }

}
