using AutoMapper;
using MovieRental.Business.ViewModels.CommentVMs;
using MovieRental.Core.Models;

namespace MovieRental.Business.Profiles
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<Comment, CommentListItemVM>();
            CreateMap<CommentCreateVM, Comment>();
            CreateMap<CommentUpdateVM, Comment>();
            CreateMap<Comment, CommentUpdateVM>();
        }
    }
}
