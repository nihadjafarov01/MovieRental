namespace MovieRental.Business.ViewModels.MovieVMs
{
    public class MovieListItemVM
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string ImdbId { get; set; }
        public float LocalRating { get; set; }
    }
}
