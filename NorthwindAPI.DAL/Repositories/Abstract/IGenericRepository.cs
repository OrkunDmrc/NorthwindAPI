using NorthwindAPI.Core.Entities.Abstract;
using NorthwindAPI.Core.Results.Abstract;
using System.Linq.Expressions;

namespace NorthwindAPI.DAL.Repository.Abstract
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        Task<IResult<List<T>>> GetListAsync();

        Task<IResult<T>> GetAsync(int id);

        Task<IResult<T>> InsertAsync(T entity);

        Task<IResult<T>> UpdateAsync(T entity);

        Task<IResult<T>> DeleteAsync(int id);

    }
}
