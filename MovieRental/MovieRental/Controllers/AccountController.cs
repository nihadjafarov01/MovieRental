using Microsoft.AspNetCore.Mvc;
using MovieRental.Business.Services.Interfaces;

namespace MovieRental.Controllers
{
    public class AccountController : Controller
    {
        IUserService _userService { get; }

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var myProfile = await _userService.GetMyProfileAsync();
            return View(myProfile);
        }
    }
}
