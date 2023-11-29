using Microsoft.AspNetCore.Mvc;
using WebApiUsingIdentity.Models;

namespace WebApiUsingIdentity.DAL.Interface
{
    public interface IProduct
    {
        public Task<IEnumerable<Product>> GetAllProducts();
        Task<int> AddProduct(AddProduct addproduct);
    }
    public interface IContactUs
    {
        Task<int> AddContactUs(ContactUs contactUs);
    }
    public interface IProductRepository
    {
        Task<TopRatedProductsResponse> GetTopRatedProduct_v2();
    }

}
