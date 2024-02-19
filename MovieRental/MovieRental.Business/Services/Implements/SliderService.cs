using AutoMapper;
using MovieRental.Business.Repositories.Interfaces;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Business.ViewModels.AdminVMs.SliderVMs;
using MovieRental.Business.ViewModels.SliderVMs;
using MovieRental.Core.Models;

namespace MovieRental.Business.Services.Implements
{
    public class SliderService : ISliderService
    {
        ISliderRepository _sliderRepository { get; set; }
        IMapper _mapper { get; set; }

        public SliderService(ISliderRepository sliderRepository, IMapper mapper)
        {
            _sliderRepository = sliderRepository;
            _mapper = mapper;
        }

        public IEnumerable<AdminSliderListItemVM> AdminGetAll()
        {
            var models = _sliderRepository.GetAll(true, "Movie");
            var vms = _mapper.Map<IEnumerable<AdminSliderListItemVM>>(models);
            return vms;
        }

        public async Task CreateAsync(AdminSliderCreateVM vm)
        {
            var model = _mapper.Map<Slider>(vm);
            await _sliderRepository.CreateAsync(model);
            await _sliderRepository.SaveAsync();
        }

        public async Task<AdminSliderUpdateVM> UpdateAsync(int id)
        {
            var model = await _sliderRepository.GetByIdAsync(id);
            var vm = _mapper.Map<AdminSliderUpdateVM>(model);
            return vm;
        }

        public async Task UpdateAsync(int id, AdminSliderUpdateVM vm)
        {
            var model = await _sliderRepository.GetByIdAsync(id, false);
            _mapper.Map(vm, model);
            await _sliderRepository.SaveAsync();
        }

        public IEnumerable<SliderListItemVM> GetAll()
        {
            var models = _sliderRepository.GetAll(true, "Movie");
            var vms = _mapper.Map<IEnumerable<SliderListItemVM>>(models);
            return vms;
        }

        public async Task AdminRemoveAsync(int id)
        {
            await _sliderRepository.RemoveAsync(id);
            await _sliderRepository.SaveAsync();
        }
    }
}
