using MovieRentalAPI.Domain.Entities.Common;

namespace MovieRentalAPI.Domain.Entities
{
    public class Movie : BaseEntity
    {
        public string ImdbId { get; set; }
        public float LocalRating { get; set; }
    }
}
