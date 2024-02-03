using Microsoft.AspNetCore.Mvc;
using MovieRental.Business.Services.Interfaces;

namespace MovieRental.Controllers
{
    public class HomeController : Controller
    {
        readonly IMovieService _movieService;

        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            var data = _movieService.GetAll();
            return View(data);
        }
    }
}
