using Microsoft.AspNetCore.Mvc;
using WebApiUsingIdentity.Models;

namespace WebApiUsingIdentity.DAL.Interface
{
    public interface IProduct
    {
        public Task<IEnumerable<Product>> GetAllProducts();
        Task<int> AddProduct(AddProduct addproduct);
    }
}
