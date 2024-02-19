using MovieRental.Core.Models;

namespace MovieRental.Business.ViewModels.AdminVMs.MovieVMs
{
    public class AdminMovieListItemVM
    {
        public int Id { get; set; }
        public string TrailerUrl { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string ImdbId { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Post> Posts { get; set; }
    }
}
