using MovieRental.Business.ViewModels.ReviewVMs;

namespace MovieRental.Business.ViewModels.MovieVMs
{
    public class MovieListItemVM
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string ImdbId { get; set; }
        public float LocalRating { get; set; }
        public IEnumerable<MovieReviewsListItemVM> Reviews { get; set; }
    }
}
