using Microsoft.EntityFrameworkCore;
using ShoppingCart.Infrastracture.Specification;
using ShoppingCart.SharedKernel;
using ShoppingCart.SharedKernel.Interfaces;

namespace ShoppingCart.Infrastracture.Persistence
{
    public class GenericRepository<T, TId> : IGenericRepository<T, TId> where T : BaseEntity<TId>
    {
        protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(TId id)
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

            return result.Entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            //TODO fix
            var result = _context.Set<T>().Update(entity);

            return result.Entity;
        }

        public async Task DeleteAsync(T entity)
        {
            //TODO fix
            _context.Set<T>().Remove(entity);
        }
    }
}
