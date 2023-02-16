using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace EventAttic.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly ApplicationDbContext _context;

        public EntityBaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(i => i.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;

            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var getAllArtistList = await _context.Set<T>().ToListAsync();
            return getAllArtistList;
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperties) => current.Include(includeProperties/*includeProperty*/));
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            var GetItemModelById = await _context.Set<T>().FirstOrDefaultAsync(i => i.Id == id);
            return GetItemModelById;
        }

        public async Task UpdateAsync(int? id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;

            await _context.SaveChangesAsync();

        }
    }
}
