﻿using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repository.Abstract;

namespace NorthwindAPI.DAL.Repositories.Abstract
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<IResult<Category>> GetByProductId(int id);
    }
}
