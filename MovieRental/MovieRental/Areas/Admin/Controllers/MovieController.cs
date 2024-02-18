using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Business.ViewModels.AdminVMs.MovieVMs;
using MovieRental.Business.ViewModels.CommonVMs;
using MovieRental.Business.ViewModels.MovieVMs;
using System.Data;

namespace MovieRental.Areas.Admin.Controllers
{
    [Authorize]
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
            var datas = _movieService.GetAll().Take(5);
            int totalCount = _movieService.GetAll().Count();
            PaginationVM<IEnumerable<MovieListItemVM>> pag = new(totalCount, 1, (int)Math.Ceiling((decimal)totalCount / 5), datas); 
            return View(pag);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MovieCreateVM vm)
        {
            await _movieService.CreateAsync(vm);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, MovieUpdateVM vm)
        {
            await _movieService.UpdateAsync(id, vm);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var vm = await _movieService.UpdateAsync(id);
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _movieService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> MoviePagination(int page = 1, int count = 5)
        {
            var datas = _movieService.GetAll().Skip((page - 1) * count).Take(count);
            int totalCount = _movieService.GetAll().Count();
            PaginationVM<IEnumerable<MovieListItemVM>> pag = new(totalCount, page, (int)Math.Ceiling((decimal)totalCount / count), datas);
            return PartialView("_MoviePaginationPartialView", pag);
        }
    }
}
    