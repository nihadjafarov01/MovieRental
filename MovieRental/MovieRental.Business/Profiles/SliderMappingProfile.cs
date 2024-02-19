using AutoMapper;
using MovieRental.Business.ViewModels.AdminVMs.SliderVMs;
using MovieRental.Business.ViewModels.SliderVMs;
using MovieRental.Core.Models;

namespace MovieRental.Business.Profiles
{
    public class SliderMappingProfile : Profile
    {
        public SliderMappingProfile()
        {
            CreateMap<Slider, AdminSliderListItemVM>();
            CreateMap<AdminSliderCreateVM, Slider>();
            CreateMap<AdminSliderUpdateVM, Slider>();
            CreateMap<Slider, AdminSliderUpdateVM>();
            CreateMap<Slider, SliderListItemVM>();
        }
    }
}
