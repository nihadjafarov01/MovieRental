﻿using AutoMapper;
using AutoMapper.Execution;
using MovieRental.Business.ViewModels.AdminVMs.MovieVMs;
using MovieRental.Business.ViewModels.MovieVMs;
using MovieRental.Core.Models;

namespace MovieRental.Business.Profiles
{
    public class MovieMappingProfile : Profile
    {
        public MovieMappingProfile()
        {
            CreateMap<Movie, MovieListItemVM>();
            CreateMap<Movie, AdminMovieListItemVM>();
            CreateMap<MovieCreateVM, Movie>();
            CreateMap<MovieUpdateVM, Movie>();
            CreateMap<Movie, MovieUpdateVM>();
        }
    }
}
