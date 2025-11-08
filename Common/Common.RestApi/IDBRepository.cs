using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Common.RestApi
{
    public interface IDBRepository
    {
        DbContext Context { get; }
        Task<List<T>> GetAllAsync<T>(Expression<Func<T, bool>> expression = null) where T : class;
        Task<int> SaveChanges();

        #region Single
        Task<T> GetAsync<T>(Expression<Func<T, bool>> expression) where T : class;
        Task AddAsync<T>(T entity) where T : class;
        Task<bool> UpdateAsync<T>(Guid id, T entity) where T : class;
        Task DeleteAsync<T>(Expression<Func<T, bool>> expression) where T : class;
        #endregion Single

        #region Multiple
        Task AddRangeAsync<T>(List<T> entities) where T : class;
        Task DeleteRangeAsync<T>(Expression<Func<T, bool>> expression) where T : class;
        #endregion Multiple
    }
}
