using Microsoft.EntityFrameworkCore;
using MovieRentalAPI.Domain.Entities;

namespace MovieRentalAPI.Persistence.Contexts
{
    public class MovieRentalAPIDbContext : DbContext
    {
        public MovieRentalAPIDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }


    }
}
