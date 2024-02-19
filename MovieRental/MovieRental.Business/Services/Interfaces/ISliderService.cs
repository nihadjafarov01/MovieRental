using MovieRental.Business.ViewModels.AdminVMs.SliderVMs;
using MovieRental.Business.ViewModels.MovieVMs;
using MovieRental.Business.ViewModels.SliderVMs;

namespace MovieRental.Business.Services.Interfaces
{
    public interface ISliderService
    {
        public IEnumerable<AdminSliderListItemVM> AdminGetAll();
        public Task AdminRemoveAsync(int id);
        public IEnumerable<SliderListItemVM> GetAll();
        public Task CreateAsync(AdminSliderCreateVM vm);
        public Task<AdminSliderUpdateVM> UpdateAsync(int id);
        public Task UpdateAsync(int id, AdminSliderUpdateVM vm);

    }
}
