using MovieRental.Business.ViewModels.MovieVMs;
using MovieRental.Business.ViewModels.UserVMs;
using System.Collections.Generic;

namespace MovieRental.Business.Services.Interfaces
{
    public interface ILayoutService
    {
        public Task<UserVM> GetUserAsync();
        public List<MovieJson> GetSearchedMovies();
    }
}
