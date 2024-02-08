using MovieRental.Core.Models.Common;

namespace MovieRental.Core.Models
{
    public class WatchListType : BaseModel
    {
        public string Type { get; set; }
        public List<WatchList> WatchLists { get; set; }
    }
}
