using MovieRental.Core.Models;

namespace MovieRental.Business.ViewModels.WatchListMovieVMs
{
    public class WatchListMovieCreateVM
    {
        public int WatchListId { get; set; }
        public WatchList WatchList { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public bool IsWatched { get; set; }
    }
}
