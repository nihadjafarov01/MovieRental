using AutoMapper;
using MovieRental.Business.Repositories.Interfaces;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Business.ViewModels.AdminVMs.ReviewVMs;
using MovieRental.Business.ViewModels.ReviewVMs;
using MovieRental.Core.Models;

namespace MovieRental.Business.Services.Implements
{
    public class ReviewService : IReviewService
    {
        readonly IReviewRepository _repo;
        readonly IMapper _mapper;
        readonly IUserService _userService;
        public ReviewService(IReviewRepository repo, IMapper mapper, IUserService userService)
        {
            _repo = repo;
            _mapper = mapper;
            _userService = userService;
        }

        public IEnumerable<ReviewListItemVM> AdminGetAll()
        {
            var models = _repo.GetAll(true, "User", "Movie");
            var vms = _mapper.Map<IEnumerable<ReviewListItemVM>>(models);
            return vms;
        }

        public async Task CreateReviewAsync(MovieReviewCreateVM vm)
        {
            string userId = await _userService.GetUserIdAsync();
            vm.UserId = userId;
            Review model = _mapper.Map<Review>(vm);
            await _repo.CreateAsync(model);
            await _repo.SaveAsync();
        }

        public IEnumerable<MovieReviewsListItemVM> GetMovieReviews(int movieId)
        {
            var data = _repo.GetAll(false, "User").Where(r => r.MovieId == movieId);
            var vms = _mapper.Map<IEnumerable<MovieReviewsListItemVM>>(data);
            return vms;
        }
    }
}
