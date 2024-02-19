using MovieRental.Core.Models.Common;

namespace MovieRental.Core.Models
{
    public class Slider : BaseModel
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public string ImageUrl { get; set; }
    }

}