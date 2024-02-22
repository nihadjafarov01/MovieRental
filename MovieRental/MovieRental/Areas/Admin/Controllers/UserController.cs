using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Areas.Admin.ViewModels.UserVMs;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Business.ViewModels.AdminVMs.MovieVMs;
using MovieRental.Business.ViewModels.CommonVMs;
using MovieRental.Business.ViewModels.MovieVMs;

namespace MovieRental.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UserController : Controller
    {
        IUserService _userService { get; set; }

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var datas = _userService.AdminGetAll().Take(5);
            int totalCount = _userService.AdminGetAll().Count();
            PaginationVM<IEnumerable<UserListItemVM>> pag = new(totalCount, 1, (int)Math.Ceiling((decimal)totalCount / 5), datas);
            return View(pag);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    await _userService.DeleteAsync(id);
        //    return RedirectToAction("Index");
        //}
        public async Task<IActionResult> UserPagination(int page = 1, int count = 5)
        {
            var datas = _userService.AdminGetAll().Skip((page - 1) * count).Take(count);
            int totalCount = _userService.AdminGetAll().Count();
            PaginationVM<IEnumerable<UserListItemVM>> pag = new(totalCount, page, (int)Math.Ceiling((decimal)totalCount / count), datas);
            return PartialView("_UserPaginationPartialView", pag);
        }
    }
}
