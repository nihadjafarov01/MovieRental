using MovieRental.Business.ViewModels.MovieVMs;
using MovieRental.Business.ViewModels.UserVMs;

namespace MovieRental.Business.Services.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<UserVM> GetAll();
        public Task<MyProfileVM> GetMyProfileAsync();
        public Task<UserVM> GetUserVMAsync();
        public Task<string> GetUserIdAsync();
        public Task<UserProfileVM> GetUserByUsernameAsync(string username);

    }
}
