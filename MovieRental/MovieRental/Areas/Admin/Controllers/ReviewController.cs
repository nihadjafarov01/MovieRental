using Microsoft.AspNetCore.Mvc;

namespace MovieRental.Areas.Admin.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
