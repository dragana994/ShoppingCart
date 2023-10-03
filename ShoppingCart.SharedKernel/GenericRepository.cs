using Microsoft.EntityFrameworkCore;
using ShoppingCart.SharedKernel.Interfaces;
using ShoppingCart.SharedKernel.Specification;

namespace ShoppingCart.SharedKernel
{
    public class GenericRepository<T, TId, TRepository> : IGenericRepository<T, TId, TRepository> where T : BaseEntity<TId> where TRepository : DbContext
    {
        protected readonly TRepository _context;

        public GenericRepository(TRepository context)
        {
            _context = context;
        }

        public async Task<T?> GetByIdAsync(TId id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetListAsync(ISpecification<T> specification)
        {
            return await SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification).ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public T Update(T entity)
        {
            var result = _context.Set<T>().Update(entity);
            _context.SaveChanges();

            return result.Entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
