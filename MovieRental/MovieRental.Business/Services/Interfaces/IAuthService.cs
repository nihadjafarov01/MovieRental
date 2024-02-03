using Microsoft.AspNetCore.Identity;
using MovieRental.Business.ViewModels.AuthVMs;

namespace MovieRental.Business.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<IdentityResult> Register(RegisterVM vm);
        public Task<SignInResult> Login(LoginVM vm);
        public Task<bool> CreateInits();
        public Task Logout();
    }
}
