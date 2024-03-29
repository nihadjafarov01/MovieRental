﻿using AutoMapper;
using MovieRental.Business.ViewModels.AdminVMs.CommentVMs;
using MovieRental.Business.ViewModels.AdminVMs.MovieVMs;
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
            CreateMap<Comment, AdminCommentListItemVM>();
        }
    }
}
