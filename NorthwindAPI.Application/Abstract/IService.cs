using NorthwindAPI.Domain.Entities.Abstract;


namespace NorthwindAPI.Application.Abstract
{
    public interface IService<T> where T : class, IEntity
    {
        Task<List<T>> GetListAsync();
        Task<T> GetAsync(int id);
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(int id, T entity);
        Task DeleteAsync(T entity);
    }
}
