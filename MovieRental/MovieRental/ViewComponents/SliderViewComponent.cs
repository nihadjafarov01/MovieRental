using Microsoft.AspNetCore.Mvc;
using MovieRental.Business.Services.Interfaces;

namespace MovieRental.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        ISliderService _sliderService;

        public SliderViewComponent(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var models = _sliderService.GetAll();
            return View(models);
        }
    }
}
