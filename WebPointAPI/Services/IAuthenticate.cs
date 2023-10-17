using Microsoft.AspNetCore.Identity;

namespace WebPointAPI.Services
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string email, string password);

        Task<bool> RegisterUser(string email, string password);

        Task<IdentityUser> GetUserByEmail(string email); 

        Task Logout();
    }
}
