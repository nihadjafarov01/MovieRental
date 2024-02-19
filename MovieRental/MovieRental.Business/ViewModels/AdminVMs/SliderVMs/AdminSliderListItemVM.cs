using MovieRental.Core.Models;

namespace MovieRental.Business.ViewModels.AdminVMs.SliderVMs
{
    public class AdminSliderListItemVM
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public string ImageUrl { get; set; }
    }
}
