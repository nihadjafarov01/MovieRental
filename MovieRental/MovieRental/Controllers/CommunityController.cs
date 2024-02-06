using Microsoft.AspNetCore.Mvc;
using MovieRental.Business.Services.Interfaces;
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
            return View(data);
        }
        public IActionResult Posts([FromRoute] string tagTitle)
        {
            var data = _postService.GetAll().Where(p => p.Tag.Title.ToLower() == tagTitle.ToLower());
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostCreateVM vm)
        {
            if(!ModelState.IsValid)
            {
                return View(vm);
            }
            await _postService.CreateAsync(vm);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Post(int postId)
        {
            var vm = await _postService.GetVmByIdAsync(postId);
            return View(vm);
        }
    }
}
