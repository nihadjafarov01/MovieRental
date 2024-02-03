using AutoMapper;
using MovieRental.Business.ViewModels.UserVMs;
using MovieRental.Core.Models;

namespace MovieRental.Business.Profiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<AppUser,UserVM>();
            CreateMap<AppUser,MyProfileVM>();
            CreateMap<AppUser,UserProfileVM>();
        }
    }
}
