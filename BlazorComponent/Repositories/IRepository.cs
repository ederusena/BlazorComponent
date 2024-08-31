namespace BlazorComponent.Repositories
{
    public interface IRepository<T>
    {
        Task AddAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task RemoveAsync(int id);
        Task UpdateAsync(T entity);
    }
}
