using Microsoft.AspNetCore.Http;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Business.ViewModels.MovieVMs;
using MovieRental.Business.ViewModels.UserVMs;
using MovieRental.Core.Models;
using MovieRental.DAL.Contexts;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace MovieRental.Business.Services.Implements
{
    public class LayoutService : ILayoutService
    {
        readonly IMovieService _movieService;
        readonly IUserService _userService;

        public LayoutService(IUserService userService, IMovieService movieService)
        {
            _userService = userService;
            _movieService = movieService;
        }

        public async Task<UserVM> GetUserAsync()
        {
            UserVM userVM = await _userService.GetUserVMAsync();
            return userVM;
        }
        public List<MovieJson> GetSearchedMovies()
        {
            IEnumerable<MovieListItemVM> movieListItemVMs = _movieService.GetAll();
            List<MovieJson> rMovies = new List<MovieJson>();
            foreach (var item in movieListItemVMs)
            {
                rMovies.Add(new MovieJson { ImdbId = item.ImdbId, Id = item.Id});
            }
            return rMovies;
        }
    }
}
