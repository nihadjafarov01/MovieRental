using MovieRental.Business.ViewModels.PostVMs;
using MovieRental.Business.ViewModels.WatchListVMs;

namespace MovieRental.Business.Services.Interfaces
{
    public interface IWatchListService
    {
        public Task CreateAsync(WatchListCreateVM vm);
    }
}
