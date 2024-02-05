using MovieRental.Core.Models.Common;

namespace MovieRental.Core.Models
{
    public class Post : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public int? MovieId { get; set; }
        public Movie Movie { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
