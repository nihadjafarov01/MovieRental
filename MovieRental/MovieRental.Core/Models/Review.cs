using MovieRental.Core.Models.Common;

namespace MovieRental.Core.Models
{
    public class Review : BaseModel
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
