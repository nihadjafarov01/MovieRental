using MovieRental.Business.ViewModels.MovieVMs;
using MovieRental.Business.ViewModels.UserVMs;
using MovieRental.Core.Models;

namespace MovieRental.Business.Services.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<UserVM> GetAll();
        public Task<MyProfileVM> GetMyProfileAsync();
        public Task<UserVM> GetUserVMAsync();
        public Task<string> GetUserIdAsync();
        public Task<UserProfileVM> GetUserByUsernameAsync(string username);
        public Task<AppUser> GetCurrentUserAsync();

    }
}
