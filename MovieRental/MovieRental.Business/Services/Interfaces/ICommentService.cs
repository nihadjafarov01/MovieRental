using MovieRental.Business.ViewModels.AdminVMs.MovieVMs;
using MovieRental.Business.ViewModels.CommentVMs;
using MovieRental.Business.ViewModels.MovieVMs;

namespace MovieRental.Business.Services.Interfaces
{
    public interface ICommentService
    {
        public IEnumerable<CommentListItemVM> GetAll();
        public Task<CommentListItemVM> GetByIdAsync(int id);
        public Task CreateAsync(CommentCreateVM vm);
        public Task DeleteAsync(int id);
        public Task UpdateAsync(CommentUpdateVM vm);
    }
}
