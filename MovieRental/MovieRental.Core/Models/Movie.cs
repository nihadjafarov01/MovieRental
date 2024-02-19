using MovieRental.Core.Models.Common;

namespace MovieRental.Core.Models
{
    public class Movie : BaseModel
    {
        public string ImdbId { get; set; }
        public string TrailerUrl { get; set; }
        public Slider Slider { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Post> Posts { get; set; }
        public List<WatchListMovie> WatchListMovies { get; set; }
    }
}
