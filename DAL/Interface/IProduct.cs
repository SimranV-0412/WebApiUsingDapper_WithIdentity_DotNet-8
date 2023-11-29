using Microsoft.AspNetCore.Mvc;
using WebApiUsingIdentity.Models;

namespace WebApiUsingIdentity.DAL.Interface
{
    public interface IProduct
    {
        public Task<IEnumerable<Product>> GetAllProducts();
        Task<int> AddProduct(AddProduct addproduct);
        Task<int> AddContactUs(ContactUs contactUs);
    }
    public interface IProductRepository
    {
        Task<List<Product_v2>> GetTopRatedProduct_v2(string userId);
        // Other methods for CRUD operations, filtering, etc.
    }

}
