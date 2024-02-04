using AutoMapper;
using MovieRental.Business.ViewModels.ReviewVMs;
using MovieRental.Core.Models;

namespace MovieRental.Business.Profiles
{
    public class ReviewMappingProfile : Profile
    {
        public ReviewMappingProfile()
        {
            CreateMap<Review, MovieReviewsListItemVM>();
            CreateMap<MovieReviewCreateVM, Review>();
        }
    }
}
