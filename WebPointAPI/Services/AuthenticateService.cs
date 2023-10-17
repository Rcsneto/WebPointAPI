using Microsoft.AspNetCore.Identity;

namespace WebPointAPI.Services
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        
        private readonly UserManager<IdentityUser> _userManager;  

        public AuthenticateService(SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager; 
        }
        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email,password,false,lockoutOnFailure:false);

            return result.Succeeded;
        }

        public async Task<IdentityUser> GetUserByEmail(string email)
        {
            var result = await _userManager.FindByEmailAsync(email);

            return result;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> RegisterUser(string email, string password)
        {
            var AppUser = new IdentityUser
            {
                UserName = email,
                Email = email,
            };

            var result = await _userManager.CreateAsync(AppUser,password);

            if(result.Succeeded)
            {
                await _signInManager.SignInAsync(AppUser,isPersistent:false);
            }
            return result.Succeeded;
        }
    }
}
