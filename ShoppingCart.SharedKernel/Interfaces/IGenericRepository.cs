namespace ShoppingCart.SharedKernel.Interfaces
{
    public interface IGenericRepository<T, TId> where T : BaseEntity<TId>
    {
        Task<T?> GetByIdAsync(TId id);
        Task<List<T>> GetListAsync();
        Task<List<T>> GetListAsync(ISpecification<T> specification);

        Task<T> AddAsync(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
