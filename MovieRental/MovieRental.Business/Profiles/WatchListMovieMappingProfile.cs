using AutoMapper;
using MovieRental.Business.ViewModels.WatchListMovieVMs;
using MovieRental.Core.Models;

namespace MovieRental.Business.Profiles
{
    public class WatchListMovieMappingProfile : Profile
    {
        public WatchListMovieMappingProfile()
        {
            CreateMap<WatchListMovieCreateVM, WatchListMovie>();
        }
    }
}
