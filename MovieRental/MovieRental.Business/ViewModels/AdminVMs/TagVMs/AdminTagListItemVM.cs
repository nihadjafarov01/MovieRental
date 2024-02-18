using MovieRental.Business.ViewModels.PostVMs;

namespace MovieRental.Business.ViewModels.AdminVMs.TagVMs
{
    public class AdminTagListItemVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<PostListItemVM> Posts { get; set; }
    }
}
