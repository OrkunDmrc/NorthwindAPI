﻿using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Concrete.Dapper
{
    public class DapperSupplyRepository : DapperGenericRepository<Supply>, ISupplyRepository
    {
    }
}