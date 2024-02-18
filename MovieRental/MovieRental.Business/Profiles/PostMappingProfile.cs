using AutoMapper;
using MovieRental.Business.ViewModels.AdminVMs.PostVMs;
using MovieRental.Business.ViewModels.PostVMs;
using MovieRental.Core.Models;

namespace MovieRental.Business.Profiles
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<Post, PostListItemVM>();
            CreateMap<PostCreateVM, Post>();
            CreateMap<Post, AdminPostListItemVM>();
        }
    }
}
