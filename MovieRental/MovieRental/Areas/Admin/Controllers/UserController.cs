using Microsoft.AspNetCore.Mvc;

namespace MovieRental.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
