using Microsoft.AspNetCore.Mvc;
using MovieRental.Business.Services.Interfaces;

namespace MovieRental.ViewComponents
{
    public class LatestMoviesViewComponent  : ViewComponent
    {
        IMovieService _movieService { get; set; }

        public LatestMoviesViewComponent(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var models = _movieService.GetLatestMovies(true);
            models = models.Take(20);
            return View(models);
        }
    }
}
