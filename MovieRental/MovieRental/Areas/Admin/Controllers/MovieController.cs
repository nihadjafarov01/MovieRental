using Microsoft.AspNetCore.Mvc;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Business.ViewModels.AdminVMs.MovieVMs;

namespace MovieRental.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MovieController : Controller
    {
        readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            var data = _movieService.GetMovieAdminVM();
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create(MovieAdminVM vm)
        {
            await _movieService.CreateAsync(vm.MovieCreateVM);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Update(MovieAdminVM vm)
        {
            await _movieService.UpdateAsync(vm.MovieUpdateVM);
            return RedirectToAction("Index");
        }
    }
}
