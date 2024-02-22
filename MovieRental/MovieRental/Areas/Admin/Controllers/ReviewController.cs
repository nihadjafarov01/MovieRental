using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Business.Services.Implements;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Business.ViewModels.AdminVMs.ReviewVMs;
using MovieRental.Business.ViewModels.CommonVMs;
using MovieRental.Business.ViewModels.MovieVMs;

namespace MovieRental.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ReviewController : Controller
    {
        IReviewService _reviewService {  get; set; }

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public IActionResult Index()
        {
            var datas = _reviewService.AdminGetAll().Take(5);
            int totalCount = _reviewService.AdminGetAll().Count();
            PaginationVM<IEnumerable<ReviewListItemVM>> pag = new(totalCount, 1, (int)Math.Ceiling((decimal)totalCount / 5), datas);
            return View(pag);
        }
        public async Task<IActionResult> ReviewPagination(int page = 1, int count = 5)
        {
            var datas = _reviewService.AdminGetAll().Skip((page - 1) * count).Take(count);
            int totalCount = _reviewService.AdminGetAll().Count();
            PaginationVM<IEnumerable<ReviewListItemVM>> pag = new(totalCount, page, (int)Math.Ceiling((decimal)totalCount / count), datas);
            return PartialView("_ReviewPaginationPartialView", pag);
        }

    }
}
