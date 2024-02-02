using MovieRental.Core.Models.Common;

namespace MovieRental.Core.Models
{
    public class Movie : BaseModel
    {
        public int ImdbId { get; set; }
        public float LocalRating { get; set; }
    }
}
