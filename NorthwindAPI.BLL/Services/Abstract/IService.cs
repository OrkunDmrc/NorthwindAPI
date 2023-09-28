﻿using NorthwindAPI.Core.Entities.Abstract;
using NorthwindAPI.Core.Results.Abstract;

namespace NorthwindAPI.BLL.Services.Abstract
{
    public interface IService<T> where T : class, IEntity
    {
        Task<IResult<List<T>>> GetListAsync();
        Task<IResult<T>> GetAsync(int id);
        Task<IResult<T>> InsertAsync(T entity);
        Task<IResult<T>> UpdateAsync(int id, T entity);
        Task<IResult<T>> DeleteAsync(int id);
    }
}