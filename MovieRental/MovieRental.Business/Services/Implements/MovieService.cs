using AutoMapper;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Business.ViewModels.AdminVMs.MovieVMs;
using MovieRental.Business.ViewModels.MovieVMs;
using MovieRental.Core.Models;
using System.Diagnostics.Metrics;

namespace MovieRental.Business.Services.Implements
{
    public class MovieService : IMovieService
    {
        IMovieRepository _repo { get; }
        IMapper _mapper { get; }

        public MovieService(IMapper mapper, IMovieRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task CreateAsync(MovieCreateVM vm)
        {
            var model = _mapper.Map<Movie>(vm);
            await _repo.CreateAsync(model);
            await _repo.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.RemoveAsync(id);
        }

        public IEnumerable<MovieListItemVM> GetAll()
        {
            var data = _repo.GetAll();
            var rdata = _mapper.Map<IEnumerable<MovieListItemVM>>(data);
            return rdata;
        }

        //public async Task<MovieUpdateVM> UpdateAsync(int id)
        //{
        //    var model = await _repo.GetByIdAsync(id);
        //    var vm = _mapper.Map<MovieUpdateVM>(model);
        //    return vm;
        //}

        //public async Task UpdateAsync(int id, MovieUpdateVM vm)
        //{
        //    var model = await _repo.GetByIdAsync(id);
        //    var rmodel = _mapper.Map(vm, model);
        //    _repo.Update(model);
        //}

        public async Task<MovieListItemVM> GetByIdAsync(int id)
        {
            var model = await _repo.GetByIdAsync(id, false, "Reviews");
            var vm = _mapper.Map<MovieListItemVM>(model);
            return vm;
        }
        public MovieAdminVM GetMovieAdminVM()
        {
            var data = _repo.GetAll();
            var adminMovieListItems = _mapper.Map<IEnumerable<AdminMovieListItemVM>>(data);
            MovieAdminVM rdata = new MovieAdminVM
            {
                MovieListItemVMs = adminMovieListItems
            };
            return rdata;
        }

        public async Task UpdateAsync(MovieUpdateVM vm)
        {
            var model = _mapper.Map<Movie>(vm);
            _repo.Update(model);
            await _repo.SaveAsync();
        }
    }
}
