using MovieRental.Core.Enums;
using MovieRental.Core.Models.Common;

namespace MovieRental.Core.Models
{
    public class WatchList : BaseModel
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int TypeId { get; set; }
        public WatchListType Type { get; set; }
        public bool IsPublic { get; set; }
    }
}
