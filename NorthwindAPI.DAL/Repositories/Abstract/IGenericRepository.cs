using NorthwindAPI.Core.Entities.Abstract;
using NorthwindAPI.Core.Results.Abstract;
using System.Linq.Expressions;

namespace NorthwindAPI.DAL.Repository.Abstract
{
    public interface IGenericRepository<T, KeyT> where T : class, IEntity
    {
        Task<IResult<IEnumerable<T>>> GetAllAsync();

        Task<IResult<T>> GetAsync(KeyT id);

        Task<IResult<T>> InsertAsync(T entity);

        Task<IResult<T>> UpdateAsync(T entity);

        Task<IResult<T>> DeleteAsync(KeyT id);

    }
}
