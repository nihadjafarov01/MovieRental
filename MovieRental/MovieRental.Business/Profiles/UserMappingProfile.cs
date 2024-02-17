using AutoMapper;
using AutoMapper.Execution;
using MovieRental.Business.Helpers;
using MovieRental.Business.ViewModels.UserVMs;
using MovieRental.Core.Models;

namespace MovieRental.Business.Profiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile(string rootPath)
        {
            CreateMap<AppUser,UserVM>();
            CreateMap<AppUser,MyProfileVM>();
            CreateMap<AppUser,UserProfileVM>();

            CreateMap<MyProfileUpdateVM, AppUser>()
                .ForMember(m => m.ProfileImageUrl, opt => opt.Ignore())
                .AfterMap(async (src, dest) =>
                {
                    if (src.ProfileImageFile != null)
                    {
                        dest.ProfileImageUrl = await src.ProfileImageFile.SaveAndProvideNameAsync(rootPath);
                    }
                });
        }

        public UserMappingProfile()
        {
        }
    }
}
