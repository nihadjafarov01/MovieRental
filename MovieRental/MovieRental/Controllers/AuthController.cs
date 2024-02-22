using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Business.ViewModels.AuthVMs;

namespace MovieRental.Controllers
{
    public class AuthController : Controller
    {
        readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var result = await _authService.Register(vm);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
            return View(vm);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var result = await _authService.Login(vm);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Username or Password is wrong");
                return View(vm);
            }
        }
        public async Task<IActionResult> Logout()
        {
            await _authService.Logout();
            return RedirectToAction("Index", "Home");
        }
        public async Task<bool> CreateInit()
        {
            return await _authService.CreateInits();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
