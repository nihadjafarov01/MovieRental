using MovieRental.Business.ViewModels.AdminVMs.MovieVMs;
using MovieRental.Business.ViewModels.MovieVMs;

namespace MovieRental.Business.Services.Interfaces
{
    public interface IMovieService
    {
        public IEnumerable<MovieListItemVM> GetAll();
        public IEnumerable<AdminMovieListItemVM> AdminGetAll();
        public Task<MovieListItemVM> GetByIdAsync(int id);
        public Task CreateAsync(MovieCreateVM vm);
        public Task DeleteAsync(int id);
        public Task UpdateAsync(int id, MovieUpdateVM vm);
        public Task<MovieUpdateVM> UpdateAsync(int id);
        public Task AddWantToWatch(int movieId);
        public Task RemoveWantToWatch(int movieId);
        public Task AddWatched(int movieId);
        public Task RemoveWatched(int movieId);
        public IEnumerable<MovieListItemVM> GetPopularMovies(bool des);
        public IEnumerable<MovieListItemVM> GetRatingMovies(bool des);
        public IEnumerable<MovieListItemVM> GetLatestMovies(bool des);
    }
}
