﻿using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Abstract
{
    public interface IProductRepository : IGenericRepository<Product, int>
    {
        Task<IResult<IEnumerable<Product>>> GetAllByCategoryIdAsync(int id);
        Task<IResult<IEnumerable<Product>>> GetAllBySupplierIdAsync(int id);
    }
}
