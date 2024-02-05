namespace MovieRental.Business.ViewModels.AdminVMs.MovieVMs
{
    public class MovieAdminVM
    {
        public IEnumerable<AdminMovieListItemVM> MovieListItemVMs { get; set; }
        public MovieCreateVM MovieCreateVM { get; set; }
        public MovieUpdateVM MovieUpdateVM { get; set; }
    }
}
