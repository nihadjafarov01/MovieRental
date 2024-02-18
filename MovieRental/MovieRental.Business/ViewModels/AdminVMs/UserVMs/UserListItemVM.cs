using MovieRental.Core.Models;

namespace MovieRental.Areas.Admin.ViewModels.UserVMs
{
    public class UserListItemVM
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? ProfileImageUrl { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsVerified { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }
        public DateTime JoinedTime { get; set; } = DateTime.UtcNow;
        public WatchList WatchList { get; set; }
        public bool IsPublic { get; set; }
    }
}
