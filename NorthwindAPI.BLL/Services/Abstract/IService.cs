﻿using NorthwindAPI.Core.Entities.Abstract;
using NorthwindAPI.Core.Results.Abstract;

namespace NorthwindAPI.BLL.Services.Abstract
{
    public interface IService<T, KeyT> where T : class, IEntity
    {
        Task<IResult<IEnumerable<T>>> GetAllAsync();
        Task<IResult<T>> GetAsync(KeyT id);
        Task<IResult<T>> InsertAsync(T entity);
        Task<IResult<T>> UpdateAsync(T entity);
        Task<IResult<T>> DeleteAsync(KeyT id);
    }
}
