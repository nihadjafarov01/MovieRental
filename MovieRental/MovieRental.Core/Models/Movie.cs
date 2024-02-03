using MovieRental.Core.Models.Common;

namespace MovieRental.Core.Models
{
    public class Movie : BaseModel
    {
        public string ImdbId { get; set; }
        public float LocalRating { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
