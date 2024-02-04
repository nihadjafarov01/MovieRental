using MovieRental.Core.Models;

namespace MovieRental.Business.ViewModels.ReviewVMs
{
    public class MovieReviewsListItemVM
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public byte RatingValue { get; set; }
        public AppUser User { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
