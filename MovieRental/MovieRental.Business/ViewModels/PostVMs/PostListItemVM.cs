using MovieRental.Core.Models;

namespace MovieRental.Business.ViewModels.PostVMs
{
    public class PostListItemVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public int? MovieId { get; set; }
        public Movie Movie { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
