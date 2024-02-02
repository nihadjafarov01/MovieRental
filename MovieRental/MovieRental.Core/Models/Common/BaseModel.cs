namespace MovieRental.Core.Models.Common
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
