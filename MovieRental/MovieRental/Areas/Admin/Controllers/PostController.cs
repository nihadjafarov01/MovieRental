using Microsoft.AspNetCore.Mvc;

namespace MovieRental.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
