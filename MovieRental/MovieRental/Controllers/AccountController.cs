using Microsoft.AspNetCore.Mvc;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Business.ViewModels.UserVMs;

namespace MovieRental.Controllers
{
    public class AccountController : Controller
    {
        IWebHostEnvironment _webHostEnvironment;
        IUserService _userService { get; }

        public AccountController(IUserService userService, IWebHostEnvironment webHostEnvironment)
        {
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var myProfile = await _userService.GetMyProfileAsync();
            return View(myProfile);
        }
        [HttpPost]
        public async Task<IActionResult> Update(MyProfileVM vm)
        {
            if(vm.MyProfileUpdateVM != null)
            {
                if(vm.MyProfileUpdateVM.IsPublic != null)
                {
                    await _userService.ChangeVisibility(vm.MyProfileUpdateVM);
                }
                if(vm.MyProfileUpdateVM.ProfileImageFile != null)
                {
                    await _userService.ChangeProfileImage(vm.MyProfileUpdateVM, _webHostEnvironment.WebRootPath);
                }
            }
            else
            {
                await _userService.RemoveProfileImage();
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> MyWatchList()
        {
            var vm = await _userService.GetCurrentUserAsync();
            return View(vm.WatchList);
        }
    }
}
