using MovieRental.Business.ViewModels.PostVMs;

namespace MovieRental.Business.ViewModels.TagVMs
{
    public class TagListItemVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<PostListItemVM> Posts { get; set; }
    }
}
