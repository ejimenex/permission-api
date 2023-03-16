using Microsoft.EntityFrameworkCore;
using PermissionApi.Application.Contract.Persistence;

namespace PermissionApi.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly PermissionDataContext _dbContext;
        public BaseRepository(PermissionDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public virtual async Task DeleteAsync(int Id)
        {
            var data = await GetByIdAsync(Id);
            _dbContext.Set<T>().Remove(data);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<T> GetByIdAsync(int Id) => await _dbContext.Set<T>().FindAsync(Id);
        public virtual async Task<IReadOnlyList<T>> ListAllAsync() => await _dbContext.Set<T>().ToListAsync();

        public virtual async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}