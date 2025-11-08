using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Common.RestApi
{
    public class DBRepository : IDBRepository
    {
        public DbContext Context { get; }

        public DBRepository(DbContext _dbContext)
        {
            Context = _dbContext;
        }
        public async Task<List<T>> GetAllAsync<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return await Context.Set<T>().Where(expression).ToListAsync();
        }
        public async Task<int> SaveChanges()
        {
            return await Context.SaveChangesAsync();
        }

        #region Single
        public async Task AddAsync<T>(T entity) where T : class
        {
            await Context.AddAsync<T>(entity);
        }

        public async Task DeleteAsync<T>(Expression<Func<T, bool>> expression) where T : class
        {
            var entity = await GetAsync<T>(expression);
            Context.Remove(entity);
        }

        public async Task<T> GetAsync<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return await Context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<bool> UpdateAsync<T>(Guid id, T entity) where T : class
        {
            return false;
        }
        #endregion Single

        #region Multiple
        public async Task AddRangeAsync<T>(List<T> entities) where T : class
        {
            await Context.AddRangeAsync(entities);
        }

        public async Task DeleteRangeAsync<T>(Expression<Func<T, bool>> expression) where T : class
        {
            var entities = await GetAllAsync<T>(expression);
            Context.RemoveRange(entities);
        }
        #endregion Multiple
    }
}
