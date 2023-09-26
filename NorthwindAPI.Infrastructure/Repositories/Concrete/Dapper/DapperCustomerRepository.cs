﻿using NorthwindAPI.Domain.Entities.Concrete;
using NorthwindAPI.Infrastructure.Repositories.Abstract;

namespace NorthwindAPI.Infrastructure.Repositories.Concrete.Dapper
{
    public class DapperCustomerRepository : DapperGenericRepository<Customer>, ICustomerRepository
    {
    }
}