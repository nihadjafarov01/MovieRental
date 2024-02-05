using MovieRental.Core.Models;

namespace MovieRental.Business.ViewModels.PostVMs
{
    public class PostCreateVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TagId { get; set; }
        public Tag? Tag { get; set; }
        public int? MovieId { get; set; }
        public Movie? Movie { get; set; }
        public string? UserId { get; set; }
    }
}
