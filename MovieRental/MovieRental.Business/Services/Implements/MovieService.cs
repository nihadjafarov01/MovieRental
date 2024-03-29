﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        IUserService _userService { get; }
        public MovieService(IMapper mapper, IMovieRepository repo, IUserService userService)
        {
            _mapper = mapper;
            _repo = repo;
            _userService = userService;
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
            await _repo.SaveAsync();
        }

        public IEnumerable<MovieListItemVM> GetRatingMovies(bool des)
        {
            var data = _repo.GetAll(true, "Reviews");
            var rdata = _mapper.Map<IEnumerable<MovieListItemVM>>(data);
            foreach (var item in rdata)
            {
                if (item.Reviews.Any())
                {
                    item.LocalRating = (float)item.Reviews.Average(r => r.RatingValue);
                }
                else
                {
                    item.LocalRating = 0;
                }
            }
            if (des)
            {
                rdata = rdata.OrderByDescending(m => m.LocalRating);
            }
            else
            {
                rdata = rdata.OrderBy(m => m.LocalRating);
            }
            rdata = rdata.Take(100);
            return rdata;
        }
        public IEnumerable<MovieListItemVM> GetAll()
        {
            var data = _repo.GetAll(true, "Reviews");
            var rdata = _mapper.Map<IEnumerable<MovieListItemVM>>(data);
            return rdata;
        }
        public async Task<MovieListItemVM> GetByIdAsync(int id)
        {
            var model = await _repo.GetByIdAsync(id, false, "Reviews");
            var vm = _mapper.Map<MovieListItemVM>(model);
            var user = await _userService.GetCurrentUserAsync();
            //if (vm.Reviews.Any())
            //{
            //    vm.LocalRating = (float)vm.Reviews.Average(r => r.RatingValue);
            //}
            //else
            //{
            //    vm.LocalRating = 0;
            //}
            vm.WatchListMovies = user.WatchList.WatchListMovies.Where(m => m.Movie.Id == id).ToList();
            return vm;
        }
        public async Task AddWantToWatch(int movieId)
        {
            var movie = await _repo.GetByIdAsync(movieId, false, "WatchListMovies");
            var user = await _userService.GetCurrentUserAsync();
            movie.WatchListMovies.Add(new WatchListMovie { MovieId = movieId, WatchListId = user.WatchList.Id});
            await _repo.SaveAsync();
        }
        public async Task RemoveWantToWatch(int movieId)
        {
            var movie = await _repo.GetByIdAsync(movieId, false, "WatchListMovies");
            var user = await _userService.GetCurrentUserAsync();
            var watchListMovie = movie.WatchListMovies.SingleOrDefault(w => w.IsWatched == false && w.WatchListId == user.WatchList.Id);
            var result = movie.WatchListMovies.Remove(watchListMovie);
            await _repo.SaveAsync();
        }

        public async Task AddWatched(int movieId)
        {
            var movie = await _repo.GetByIdAsync(movieId, false, "WatchListMovies");
            var user = await _userService.GetCurrentUserAsync();
            movie.WatchListMovies.Add(new WatchListMovie { MovieId = movieId, WatchListId = user.WatchList.Id, IsWatched = true });
            await _repo.SaveAsync();
        }

        public async Task RemoveWatched(int movieId)
        {
            var movie = await _repo.GetByIdAsync(movieId, false, "WatchListMovies");
            var user = await _userService.GetCurrentUserAsync();
            var watchListMovie = movie.WatchListMovies.SingleOrDefault(w => w.IsWatched == true && w.WatchListId == user.WatchList.Id);
            var result = movie.WatchListMovies.Remove(watchListMovie);
            await _repo.SaveAsync();
        }

        public async Task UpdateAsync(int id, MovieUpdateVM vm)
        {
            var model = await _repo.GetByIdAsync(id, false);
            _mapper.Map(vm, model);
            await _repo.SaveAsync();
        }

        public async Task<MovieUpdateVM> UpdateAsync(int id)
        {
            var model = await _repo.GetByIdAsync(id);
            var vm = _mapper.Map<MovieUpdateVM>(model);
            return vm;
        }

        public IEnumerable<AdminMovieListItemVM> AdminGetAll()
        {
            var models = _repo.GetAll();
            var vms = _mapper.Map<IEnumerable<AdminMovieListItemVM>>(models);
            return vms;
        }

        public IEnumerable<MovieListItemVM> GetPopularMovies(bool des)
        {
            var data = _repo.GetAll(true, "Reviews", "WatchListMovies");
            var rdata = _mapper.Map<IEnumerable<MovieListItemVM>>(data);
            foreach (var item in rdata)
            {
                if (item.Reviews.Any())
                {
                    item.LocalRating = (float)item.Reviews.Average(r => r.RatingValue);
                }
                else
                {
                    item.LocalRating = 0;
                }
            }
            if (des)
            {
                rdata = rdata.OrderByDescending(m => m.WatchListMovies.Count());
            }
            else
            {
                rdata = rdata.OrderBy(m => m.WatchListMovies.Count());
            }
            rdata = rdata.Take(100);
            return rdata;
        }

        public IEnumerable<MovieListItemVM> GetLatestMovies(bool des)
        {
            var data = _repo.GetAll();
            var rdata = _mapper.Map<IEnumerable<MovieListItemVM>>(data);
            if (des)
            {
                rdata = rdata.OrderByDescending(m => m.CreatedTime);
            }
            else
            {
                rdata = rdata.OrderBy(m => m.CreatedTime);
            }
            rdata = rdata.Take(100);
            return rdata;
        }
    }
}
