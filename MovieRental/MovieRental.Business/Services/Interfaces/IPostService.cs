using MovieRental.Business.ViewModels.PostVMs;

namespace MovieRental.Business.Services.Interfaces
{
    public interface IPostService
    {
        public IEnumerable<PostListItemVM> GetAll();
        public Task CreateAsync(PostCreateVM vm);
    }
}
