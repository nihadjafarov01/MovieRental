using MovieRental.Core.Models.Common;

namespace MovieRental.Core.Models
{
    public class Tag : BaseModel
    {
        public string Title { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
