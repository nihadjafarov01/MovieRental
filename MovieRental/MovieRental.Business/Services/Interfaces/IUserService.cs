using MovieRental.Business.ViewModels.MovieVMs;
using MovieRental.Business.ViewModels.UserVMs;
using MovieRental.Core.Models;

using MovieRental.Areas.Admin.ViewModels.UserVMs;

namespace MovieRental.Business.Services.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<UserVM> GetAll();
        public IEnumerable<UserListItemVM> AdminGetAll();
        public Task<MyProfileVM> GetMyProfileAsync();
        public Task<UserVM> GetUserVMAsync();
        public Task<string> GetUserIdAsync();
        public Task<UserProfileVM> GetUserByUsernameAsync(string username);
        public Task<AppUser> GetCurrentUserAsync();
        public Task ChangeVisibility(MyProfileUpdateVM vm);
        public Task ChangeProfileImage(MyProfileUpdateVM vm, string rootPath);
        public Task RemoveProfileImage();
        
    }
}
