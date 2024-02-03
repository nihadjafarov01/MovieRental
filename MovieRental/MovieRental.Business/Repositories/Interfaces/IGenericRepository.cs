using MovieRental.Core.Models.Common;
using System.Linq.Expressions;

namespace MovieRental.Business.Services.Interfaces
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        IQueryable<T> GetAll(bool noTracking = true, params string[] include);
        Task<T> GetByIdAsync(int id, bool noTracking = true, params string[] include);
        Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);
        Task CreateAsync(T data);
        void Update(T data);
        Task RemoveAsync(int id);
        Task SaveAsync();
    }
}
