using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MovieRental.Business.Services.Interfaces;

namespace MovieRental.ViewComponents
{
    public class TopMoviesViewComponent : ViewComponent
    {
        IMovieService _movieService {  get; set; }

        public TopMoviesViewComponent(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var models = _movieService.GetRatingMovies(true);
            models = models.Take(10);
            return View(models);
        }
    }
}
