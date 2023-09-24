using NorthwindAPI.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindAPI.Infrastructure.Repository.Abstract
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        Task<List<T>> GetListAsync();

        Task<T> GetAsync(int id);

        Task<T> InsertAsync(T entity);

        Task<T> UpdateAsync(int id, T entity);

        Task DeleteAsync(T entity);
    }
}
