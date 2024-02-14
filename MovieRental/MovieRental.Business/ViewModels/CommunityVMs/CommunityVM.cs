using MovieRental.Business.ViewModels.PostVMs;
using MovieRental.Business.ViewModels.TagVMs;

namespace MovieRental.Business.ViewModels.CommunityVMs
{
    public class CommunityVM
    {
        public IEnumerable<TagListItemVM> Tags { get; set; }
        public PostCreateVM PostCreateVM { get; set; }
    }
}
