using AutoMapper;
using MovieRental.Business.Repositories.Interfaces;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Business.ViewModels.WatchListMovieVMs;
using MovieRental.Core.Models;

namespace MovieRental.Business.Services.Implements
{
    public class WatchListMovieService : IWatchListMovieService
    {
        readonly IWatchListMovieRepository _watchListMovieRepository;
        readonly IUserService _userService;
        readonly IMapper _mapper;

        public WatchListMovieService(IWatchListMovieRepository watchListMovieRepository, IMapper mapper, IUserService userService)
        {
            _watchListMovieRepository = watchListMovieRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task CreateAsync(WatchListMovieCreateVM vm)
        {
            WatchListMovie model = _mapper.Map<WatchListMovie>(vm);
            AppUser user = await _userService.GetCurrentUserAsync();
            model.WatchList = user.WatchList;
            await _watchListMovieRepository.CreateAsync(model);
            await _watchListMovieRepository.SaveAsync();
        }

    }
}
