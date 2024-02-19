using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Business.Services.Implements;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Business.ViewModels.AdminVMs.SliderVMs;
using MovieRental.Business.ViewModels.AdminVMs.TagVMs;
using MovieRental.Business.ViewModels.CommonVMs;

namespace MovieRental.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class SliderController : Controller
    {
        ISliderService _sliderService { get; set; }

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public IActionResult Index()
        {
            var datas = _sliderService.AdminGetAll().Take(5);
            int totalCount = _sliderService.AdminGetAll().Count();
            PaginationVM<IEnumerable<AdminSliderListItemVM>> pag = new(totalCount, 1, (int)Math.Ceiling((decimal)totalCount / 5), datas);
            return View(pag);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdminSliderCreateVM vm)
        {
            await _sliderService.CreateAsync(vm);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var vm = await _sliderService.UpdateAsync(id);
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, AdminSliderUpdateVM vm)
        {
            await _sliderService.UpdateAsync(id, vm);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> SliderPagination(int page = 1, int count = 5)
        {
            var datas = _sliderService.AdminGetAll().Skip((page - 1) * count).Take(count);
            int totalCount = _sliderService.AdminGetAll().Count();
            PaginationVM<IEnumerable<AdminSliderListItemVM>> pag = new(totalCount, page, (int)Math.Ceiling((decimal)totalCount / count), datas);
            return PartialView("_SliderPaginationPartialView", pag);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _sliderService.AdminRemoveAsync(id);
            return RedirectToAction("Index");
        }
    }
}
