using Microsoft.AspNetCore.Mvc;
using MovieRental.Business.Services.Interfaces;

namespace MovieRental.Controllers
{
    public class MovieController : Controller
    {
        readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Index(int id)
        {
            if(id == 0 || id == null)
            {
                return BadRequest();
            }
            var data = await _movieService.GetByIdAsync(id);
            if(data == null)
            {
                return NotFound();
            }
            return View(data);
        }
    }
}
