namespace eTickets.Domain.Interfaces.Base
{
    public interface IEntityBaseRepository<T> where T : class , IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T newentity);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
