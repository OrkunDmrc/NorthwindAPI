﻿using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Abstract
{
    public interface ICustomerRepository : IGenericRepository<Customer, string>
    {
        Task<IResult<Customer>> GetByOrderIdAsync(int id);
    }
}
