using WebApiUsingIdentity.Models;

namespace WebApiUsingIdentity.DAL.Interface
{
    public interface IContactUs
    {
        Task<int> AddContactUs(ContactUs contactUs);
    }
}
