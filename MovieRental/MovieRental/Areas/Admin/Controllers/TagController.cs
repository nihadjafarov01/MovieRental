using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Business.Services.Implements;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Business.ViewModels.AdminVMs.PostVMs;
using MovieRental.Business.ViewModels.AdminVMs.TagVMs;
using MovieRental.Business.ViewModels.CommonVMs;

namespace MovieRental.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class TagController : Controller
    {
        ITagService _tagService { get; set; }

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public IActionResult Index()
        {
            var datas = _tagService.AdminGetAll().Take(5);
            int totalCount = _tagService.AdminGetAll().Count();
            PaginationVM<IEnumerable<AdminTagListItemVM>> pag = new(totalCount, 1, (int)Math.Ceiling((decimal)totalCount / 5), datas);
            return View(pag);
        }
        public async Task<IActionResult> TagPagination(int page = 1, int count = 5)
        {
            var datas = _tagService.AdminGetAll().Skip((page - 1) * count).Take(count);
            int totalCount = _tagService.AdminGetAll().Count();
            PaginationVM<IEnumerable<AdminTagListItemVM>> pag = new(totalCount, page, (int)Math.Ceiling((decimal)totalCount / count), datas);
            return PartialView("_TagPaginationPartialView", pag);
        }
    }
}
