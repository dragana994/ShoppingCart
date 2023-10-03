using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.SharedKernel.Interfaces
{
    public interface IGenericRepository<T, TId, TRepository> where T : BaseEntity<TId> where TRepository : DbContext
    {
        Task<T?> GetByIdAsync(TId id);
        Task<List<T>> GetListAsync();
        Task<List<T>> GetListAsync(ISpecification<T> specification);

        Task<T> AddAsync(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
