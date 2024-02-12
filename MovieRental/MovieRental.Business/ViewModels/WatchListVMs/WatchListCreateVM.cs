using MovieRental.Core.Models;

namespace MovieRental.Business.ViewModels.WatchListVMs
{
    public class WatchListCreateVM
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public bool IsPublic { get; set; }
        public List<WatchListMovie> WatchListMovies { get; set; }
    }
}
