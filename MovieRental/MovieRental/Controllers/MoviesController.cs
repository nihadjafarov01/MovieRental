using Microsoft.AspNetCore.Mvc;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Business.ViewModels.MovieVMs;

namespace MovieRental.Controllers
{
    public class MoviesController : Controller
    {
        IMovieService _movieService {  get; set; }

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            IEnumerable<MovieListItemVM> vms = _movieService.GetRatingMovies(true);
            return View(vms);
        }
        public IActionResult PopularMovies(bool des)
        {
            IEnumerable<MovieListItemVM> vms = _movieService.GetPopularMovies(des);
            return PartialView("_MoviesPartialView", vms);
        }
        public IActionResult RankingMovies(bool des)
        {
            IEnumerable<MovieListItemVM> vms = _movieService.GetRatingMovies(des);
            return PartialView("_MoviesPartialView", vms);
        }
        public IActionResult ReleasedMovies()
        {
            IEnumerable<MovieListItemVM> vms = _movieService.GetPopularMovies(true);
            return PartialView("_MoviesPartialView", vms);
        }
    }
}
