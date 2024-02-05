using Microsoft.AspNetCore.Mvc;

namespace MovieRental.Areas.Admin.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
