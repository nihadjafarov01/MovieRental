using MovieRental.Core.Models.Common;

namespace MovieRental.Core.Models
{
    public class Comment : BaseModel
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int? ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }
        public IEnumerable<Comment> ChildComments { get; set; }
    }
}
