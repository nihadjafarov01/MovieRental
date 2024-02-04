using MovieRental.Business.ViewModels.UserVMs;

namespace MovieRental.Business.Services.Interfaces
{
    public interface ILayoutService
    {
        public Task<UserVM> GetUserAsync();
    }
}
