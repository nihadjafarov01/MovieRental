using MovieRental.Business.ViewModels.WatchListMovieVMs;
using MovieRental.Business.ViewModels.WatchListVMs;

namespace MovieRental.Business.Services.Interfaces
{
    public interface IWatchListMovieService
    {
        public Task CreateAsync(WatchListMovieCreateVM vm);
        //public Task DeleteAsync();
    }
}
