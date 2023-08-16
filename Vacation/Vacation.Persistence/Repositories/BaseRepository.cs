using Microsoft.EntityFrameworkCore;
using Vacation.Application.Contracts;
using Vacation.Persistence.Data;

namespace Vacation.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var items = await _context.Set<T>().ToListAsync();
            return items;
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            var item = await _context.Set<T>().FindAsync(id);
            return item;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }
        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
