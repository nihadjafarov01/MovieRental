using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Business.Services.Implements;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Business.ViewModels.AdminVMs.PostVMs;
using MovieRental.Business.ViewModels.AdminVMs.ReviewVMs;
using MovieRental.Business.ViewModels.CommonVMs;

namespace MovieRental.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class PostController : Controller
    {
        IPostService _postService { get; set; }

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index()
        {
            var datas = _postService.AdminGetAll().Take(5);
            int totalCount = _postService.AdminGetAll().Count();
            PaginationVM<IEnumerable<AdminPostListItemVM>> pag = new(totalCount, 1, (int)Math.Ceiling((decimal)totalCount / 5), datas);
            return View(pag);
        }
        public async Task<IActionResult> PostPagination(int page = 1, int count = 5)
        {
            var datas = _postService.AdminGetAll().Skip((page - 1) * count).Take(count);
            int totalCount = _postService.AdminGetAll().Count();
            PaginationVM<IEnumerable<AdminPostListItemVM>> pag = new(totalCount, page, (int)Math.Ceiling((decimal)totalCount / count), datas);
            return PartialView("_PostPaginationPartialView", pag);
        }
    }
}
