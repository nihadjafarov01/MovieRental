using MovieRental.Business.ViewModels.CommentVMs;

namespace MovieRental.Business.ViewModels.PostVMs
{
    public class PostVM
    {
        public PostListItemVM PostListItemVM { get; set; }
        public CommentCreateVM CommentCreateVM { get; set; }
    }
}
