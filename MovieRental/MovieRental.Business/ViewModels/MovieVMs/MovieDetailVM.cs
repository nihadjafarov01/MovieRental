using MovieRental.Business.ViewModels.ReviewVMs;

namespace MovieRental.Business.ViewModels.MovieVMs
{
    public class MovieDetailVM
    {
        public MovieListItemVM MovieVM { get; set; }
        public IEnumerable<MovieReviewsListItemVM> ReviewsVM { get; set; }
        public MovieReviewCreateVM MovieReviewCreateVM { get; set; }
    }
}
