using MovieRental.Business.ViewModels.ReviewVMs;
using MovieRental.Core.Models;

namespace MovieRental.Business.Services.Interfaces
{
    public interface IReviewService
    {
        public IEnumerable<MovieReviewsListItemVM> GetMovieReviews(int movieId);
        public Task CreateReviewAsync(MovieReviewCreateVM vm);
    }
}
