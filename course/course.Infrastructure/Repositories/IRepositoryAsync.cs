using course.Entities;

namespace course.Infrastructure.Repositories
{
    public interface IRepositoryAsync<T> where T : IEntity
    {
        Task CreateNewAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> IsExists(int id);



    }
}
