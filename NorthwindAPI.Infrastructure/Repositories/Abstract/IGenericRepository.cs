using NorthwindAPI.Domain.Entities.Abstract;
using NorthwindAPI.Domain.Results.Abstract;

namespace NorthwindAPI.Infrastructure.Repository.Abstract
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        Task<IResult<List<T>>> GetListAsync();

        Task<IResult<T>> GetAsync(int id);

        Task<IResult<T>> InsertAsync(T entity);

        Task<IResult<T>> UpdateAsync(int id, T entity);

        Task<IResult<T>> DeleteAsync(int id);
    }
}
