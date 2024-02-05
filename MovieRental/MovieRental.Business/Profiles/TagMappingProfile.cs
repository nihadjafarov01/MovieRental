﻿using AutoMapper;
using MovieRental.Business.ViewModels.TagVMs;
using MovieRental.Core.Models;

namespace MovieRental.Business.Profiles
{
    public class TagMappingProfile : Profile
    {
        public TagMappingProfile()
        {
            CreateMap<Tag, TagListItemVM>();
        }
    }
}
