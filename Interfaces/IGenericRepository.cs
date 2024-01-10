using Net.Models;

namespace Net.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetAsync(int id);
        Task<List<T>> GetByDateRangeAsync(DateTime initDate, DateTime endDate);
        Task<bool> AddEntity(T entity);
        Task<bool> UpdateEntity(T entity);
        Task<bool> DeleteEntity(int id);

    }
}
