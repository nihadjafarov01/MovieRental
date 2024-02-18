using MovieRental.Business.ViewModels.AdminVMs.TagVMs;
using MovieRental.Business.ViewModels.MovieVMs;
using MovieRental.Business.ViewModels.TagVMs;

namespace MovieRental.Business.Services.Interfaces
{
    public interface ITagService
    {
        public IEnumerable<TagListItemVM> GetAll();
        public IEnumerable<AdminTagListItemVM> AdminGetAll();
    }
}
