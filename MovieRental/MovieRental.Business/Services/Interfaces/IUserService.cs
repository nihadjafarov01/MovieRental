using MovieRental.Business.ViewModels.MovieVMs;
using MovieRental.Business.ViewModels.UserVMs;

namespace MovieRental.Business.Services.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<UserVM> GetAll();
        public Task<MyProfileVM> GetMyProfileAsync();

    }
}
