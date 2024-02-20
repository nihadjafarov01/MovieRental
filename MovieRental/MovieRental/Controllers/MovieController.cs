using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Business.Repositories.Interfaces;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Business.ViewModels.MovieVMs;
using MovieRental.Business.ViewModels.ReviewVMs;
using MovieRental.Business.ViewModels.WatchListMovieVMs;
using System.Xml.Linq;

namespace MovieRental.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        readonly IMovieService _movieService;
        readonly IReviewService _reviewService;
        readonly IWatchListMovieService _watchListMovieService;
        readonly IUserService _userService;

        public MovieController(IMovieService movieService, IReviewService reviewService, IWatchListMovieService watchListMovieService, IUserService userService)
        {
            _movieService = movieService;
            _reviewService = reviewService;
            _watchListMovieService = watchListMovieService;
            _userService = userService;
        }

        public async Task<IActionResult> Watch(int id)
        {
            if(id == 0 || id == null)
            {
                return BadRequest();
            }
            var movie = await _movieService.GetByIdAsync(id);
            if(movie == null)
            {
                return NotFound();
            }
            IEnumerable<byte> ratings = movie.Reviews.Where(i => i.MovieId == id).Select(i => i.RatingValue);
            if(ratings.Any())
            {
                movie.LocalRating = (float)ratings.Sum(i => i)/ ratings.Count();
                movie.LocalRating = (float)Math.Round(movie.LocalRating, 1);
            }
            var reviews = _reviewService.GetMovieReviews(movie.Id);
            MovieReviewCreateVM reviewCreateVM = new();
            reviewCreateVM.MovieId = id;
            MovieDetailVM rdata = new MovieDetailVM
            {
                MovieVM = movie,
                ReviewsVM = reviews,
                MovieReviewCreateVM = reviewCreateVM
            };
            return View(rdata);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMovieReview(int movieId, MovieDetailVM vm)
        {
            vm.MovieReviewCreateVM.MovieId = movieId;
            await _reviewService.CreateReviewAsync(vm.MovieReviewCreateVM);
            return RedirectToAction("Watch", new { id = movieId });
        }
        [HttpPost]
        public async Task<IActionResult> AddWantToWatch(int movieId)
        {
            await _userService.AddWantToWatch(movieId);
            return RedirectToAction("Watch", new { id = movieId });
        }
        [HttpPost]  
        public async Task<IActionResult> RemoveWantToWatch(int movieId)
        {
            await _userService.RemoveWantToWatch(movieId);
            return RedirectToAction("Watch", new { id = movieId });
        }
        [HttpPost]
        public async Task<IActionResult> AddWatched(int movieId)
        {
            await _userService.AddWatched(movieId);
            return RedirectToAction("Watch", new { id = movieId });
        }
        [HttpPost]
        public async Task<IActionResult> RemoveWatched(int movieId)
        {
            await _userService.RemoveWatched(movieId);
            return RedirectToAction("Watch", new { id = movieId });
        }
    }
}
