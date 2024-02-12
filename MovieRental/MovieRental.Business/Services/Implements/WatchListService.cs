using AutoMapper;
using MovieRental.Business.Repositories.Interfaces;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Business.ViewModels.WatchListVMs;
using MovieRental.Core.Models;

namespace MovieRental.Business.Services.Implements
{
    public class WatchListService : IWatchListService
    {
        readonly IWatchListRepository _watchListRepository;
        readonly IMapper _mapper;

        public WatchListService(IWatchListRepository watchListRepository, IMapper mapper)
        {
            _watchListRepository = watchListRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(WatchListCreateVM vm)
        {
            WatchList model = _mapper.Map<WatchList>(vm);
            await _watchListRepository.CreateAsync(model);
            await _watchListRepository.SaveAsync();
        }
    }
}
