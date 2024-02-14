using MovieRental.Core.Enums;
using MovieRental.Core.Models.Common;

namespace MovieRental.Core.Models
{
    public class WatchList : BaseModel
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public List<WatchListMovie> WatchListMovies { get; set; }
    }
}
