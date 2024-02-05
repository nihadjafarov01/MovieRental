using MovieRental.Business.Repositories.Interfaces;
using MovieRental.Business.Services.Implements;
using MovieRental.Core.Models;
using MovieRental.DAL.Contexts;

namespace MovieRental.Business.Repositories.Implements
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(MovieRentalDbContext context) : base(context)
        {
        }
    }
}
