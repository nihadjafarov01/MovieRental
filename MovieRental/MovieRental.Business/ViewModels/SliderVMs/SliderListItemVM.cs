using MovieRental.Core.Models;

namespace MovieRental.Business.ViewModels.SliderVMs
{
    public class SliderListItemVM
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public string ImageUrl { get; set; }
    }
}
