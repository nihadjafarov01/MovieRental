using Microsoft.EntityFrameworkCore;
using MovieRental.Business.Services.Interfaces;
using MovieRental.Core.Models.Common;
using MovieRental.DAL.Contexts;
using System.Linq.Expressions;

namespace MovieRental.Business.Services.Implements
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        MovieRentalDbContext _context { get; }

        public GenericRepository(MovieRentalDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool noTracking = true, params string[] include)
        {
            var query = Table.AsQueryable();
            if (include != null && include.Length > 0)
            {
                foreach (var item in include)
                {
                    query = query.Include(item);
                }
            }
            return noTracking ? query.AsNoTracking() : query;
        }

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
        {
            return await Table.AnyAsync(expression);
        }

        public async Task CreateAsync(T data)
        {
            await Table.AddAsync(data);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id, bool noTracking = true, params string[] include)
        {
            var query = Table.AsQueryable();
            if (include != null && include.Length > 0)
            {
                foreach (var item in include)
                {
                    query = query.Include(item);
                }
            }
            return noTracking ? await query.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id) : await query.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var model = await Table.FindAsync(id);
            Table.Remove(model);
        }

        public void Update(T data)
        {
            Table.Update(data);
        }
    }
}
