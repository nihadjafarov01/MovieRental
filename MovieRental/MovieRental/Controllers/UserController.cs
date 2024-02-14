using Microsoft.AspNetCore.Mvc;
using MovieRental.Business.Services.Interfaces;

namespace MovieRental.Controllers
{
    public class UserController : Controller
    {
        readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Profile([FromRoute] string username)
        {
            if(username == null)
            {
                return BadRequest();
            }
            var vm = await _userService.GetUserByUsernameAsync(username);
            if(vm == null)
            {
                return NotFound();
            }
            return View(vm);
        }
        public async Task<IActionResult> WatchList([FromRoute] string username)
        {
            var vm = await _userService.GetUserByUsernameAsync(username);
            return View(vm.WatchList);
        }
    }
}
