using MovieRental.Business.Services.Interfaces;
using MovieRental.Core.Models;
using MovieRental.DAL.Contexts;

namespace MovieRental.Business.Services.Implements
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieRentalDbContext context) : base(context)
        {
        }
    }
}
