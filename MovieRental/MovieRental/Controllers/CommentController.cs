using Microsoft.AspNetCore.Mvc;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Business.ViewModels.CommentVMs;
using MovieRental.Business.ViewModels.PostVMs;

namespace MovieRental.Controllers
{
    public class CommentController : Controller
    {
        readonly ICommentService _commentService;
        readonly IPostService _postService;

        public CommentController(ICommentService commentService, IPostService postService)
        {
            _commentService = commentService;
            _postService = postService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(int postId, PostVM vm)
        {
            vm.CommentCreateVM.PostId = postId;
            await _commentService.CreateAsync(vm.CommentCreateVM);
            //TempData["PostVM"] = await _postService.GetVmByIdAsync(postId);
            return RedirectToAction("Post", "Community", new {postId = postId});
        }
        //[HttpPost]
        //public IActionResult Create([FromBody] PostVM vm)
        //{
        //    try
        //    {
        //        // Your comment creation logic here

        //        // Return a JSON response
        //        return Json(new { success = true, message = "Comment created successfully" });
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception
        //        Console.WriteLine(ex.Message);

        //        // Return a JSON response with error details
        //        return Json(new { success = false, message = "An error occurred while creating the comment" });
        //    }
        //}
    }
}
