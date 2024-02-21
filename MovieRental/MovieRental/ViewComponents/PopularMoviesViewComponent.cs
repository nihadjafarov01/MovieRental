using Microsoft.AspNetCore.Mvc;
using MovieRental.Business.Services.Interfaces;

namespace MovieRental.ViewComponents
{
    public class PopularMoviesViewComponent : ViewComponent
    {
        IMovieService _movieService { get; set; }

        public PopularMoviesViewComponent(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var models = _movieService.GetPopularMovies(true);
            models = models.Take(20);
            return View(models);
        }
    }
}
