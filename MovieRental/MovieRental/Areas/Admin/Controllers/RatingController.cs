using Microsoft.AspNetCore.Mvc;

namespace MovieRental.Areas.Admin.Controllers
{
    public class RatingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
