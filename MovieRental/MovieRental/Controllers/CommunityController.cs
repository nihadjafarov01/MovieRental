using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Business.ViewModels.CommunityVMs;
using MovieRental.Business.ViewModels.PostVMs;

namespace MovieRental.Controllers
{
    public class CommunityController : Controller
    {
        readonly ITagService _tagService;
        readonly IPostService _postService;

        public CommunityController(ITagService tagService, IPostService postService)
        {
            _tagService = tagService;
            _postService = postService;
        }

        public IActionResult Index()
        {
            var data = _tagService.GetAll();
            CommunityVM communityVM = new CommunityVM
            {
                Tags = data,
            };
            ViewBag.Tags = new SelectList(data, "Id", "Title");
            return View(communityVM);
        }
        public IActionResult Posts([FromRoute] string tagTitle)
        {
            var data = _postService.GetAll().Where(p => p.Tag.Title.ToLower() == tagTitle.ToLower());
            return View(data);
        }
        public async Task<IActionResult> Post(int postId)
        {
            var vm = await _postService.GetVmByIdAsync(postId);
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(CommunityVM vm)
        {
            await _postService.CreateAsync(vm.PostCreateVM);
            return RedirectToAction("Index");
        }
    }
}
