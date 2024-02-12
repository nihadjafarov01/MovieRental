using MovieRental.Core.Models.Common;

namespace MovieRental.Core.Models
{
    public class WatchListMovie : BaseModel
    {
        public int WatchListId { get; set; }
        public WatchList WatchList { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public bool IsWatched { get; set; }
    }
}
