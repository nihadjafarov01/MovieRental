using MovieRental.Core.Models.Common;

namespace MovieRental.Core.Models
{
    public class Movie : BaseModel
    {
        public string ImdbId { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Post> Posts { get; set; }
        public List<WatchList> WatchLists { get; set; }
    }
}
