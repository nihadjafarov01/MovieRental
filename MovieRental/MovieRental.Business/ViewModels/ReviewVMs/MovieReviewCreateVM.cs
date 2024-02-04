using MovieRental.Core.Models;

namespace MovieRental.Business.ViewModels.ReviewVMs
{
    public class MovieReviewCreateVM
    {
        public byte RatingValue { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public AppUser? User { get; set; }
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
    }
}
