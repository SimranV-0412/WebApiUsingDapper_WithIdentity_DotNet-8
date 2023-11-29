using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiUsingIdentity.DAL.Interface;
using WebApiUsingIdentity.Models;

namespace WebApiUsingIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        //public readonly IContactUs _ContactUs;
        public readonly IProduct _Product;
        //public ContactUsController(IContactUs ContactUs)
        //{
        //    _ContactUs = ContactUs;
        //}
        public ContactUsController(IProduct Product)
        {
            _Product = Product;
        }

        [HttpPost]
        [Route("AddContactUs")]
        public async Task<IActionResult> AddContactUs(ContactUs contactUs)
        {
            int result = 0;
            try
            {
                result = await _Product.AddContactUs(contactUs);
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
