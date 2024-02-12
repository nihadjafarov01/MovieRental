using AutoMapper;
using MovieRental.Business.ViewModels.WatchListVMs;
using MovieRental.Core.Models;

namespace MovieRental.Business.Profiles
{
    public class WatchListMappingProfile : Profile
    {
        public WatchListMappingProfile()
        {
            CreateMap<WatchListCreateVM, WatchList>();
        }
    }
}
