using MovieRental.Business.ViewModels.MovieVMs;

namespace MovieRental.Business.Services.Interfaces
{
    public interface IMovieService
    {
        public IEnumerable<MovieListItemVM> GetAll();
        public Task<MovieListItemVM> GetByIdAsync(int id);
        public Task CreateAsync(MovieCreateVM vm);
        public Task<MovieUpdateVM> UpdateAsync(int id);
        public Task UpdateAsync(int id, MovieUpdateVM vm);
        public Task DeleteAsync(int id);
    }
}
