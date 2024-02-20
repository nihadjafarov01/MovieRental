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
            IEnumerable<MovieListItemVM> vms = _movieService.GetPopularMovies();
            return View(vms);
        }
        public IActionResult PopularMovies()
        {
            IEnumerable<MovieListItemVM> vms = _movieService.GetPopularMovies();
            return RedirectToAction("Index", vms);
        }
        //public IActionResult ReleasedMovies()
        //{
        //    IEnumerable<MovieListItemVM> vms = _movieService.GetReleasedMovies();
        //    return View(vms);
        //}
    }
}
