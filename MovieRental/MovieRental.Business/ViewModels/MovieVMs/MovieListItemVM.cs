using MovieRental.Business.ViewModels.ReviewVMs;
using MovieRental.Core.Models;

namespace MovieRental.Business.ViewModels.MovieVMs
{
    public class MovieListItemVM
    {
        public int Id { get; set; }
        public string TrailerUrl { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string ImdbId { get; set; }
        public float LocalRating { get; set; }
        public IEnumerable<MovieReviewsListItemVM> Reviews { get; set; }
        public List<WatchListMovie> WatchListMovies { get; set; }
    }
}
