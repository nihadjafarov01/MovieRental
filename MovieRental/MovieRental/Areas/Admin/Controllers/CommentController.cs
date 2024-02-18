using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Business.Services.Implements;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Business.ViewModels.AdminVMs.CommentVMs;
using MovieRental.Business.ViewModels.AdminVMs.ReviewVMs;
using MovieRental.Business.ViewModels.CommonVMs;

namespace MovieRental.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class CommentController : Controller
    {
        ICommentService _commentService { get; set; }

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var datas = _commentService.AdminGetAll().Take(5);
            int totalCount = _commentService.AdminGetAll().Count();
            PaginationVM<IEnumerable<AdminCommentListItemVM>> pag = new(totalCount, 1, (int)Math.Ceiling((decimal)totalCount / 5), datas);
            return View(pag);
        }
        public async Task<IActionResult> CommentPagination(int page = 1, int count = 5)
        {
            var datas = _commentService.AdminGetAll().Skip((page - 1) * count).Take(count);
            int totalCount = _commentService.AdminGetAll().Count();
            PaginationVM<IEnumerable<AdminCommentListItemVM>> pag = new(totalCount, page, (int)Math.Ceiling((decimal)totalCount / count), datas);
            return PartialView("_CommentPaginationPartialView", pag);
        }
    }
}
