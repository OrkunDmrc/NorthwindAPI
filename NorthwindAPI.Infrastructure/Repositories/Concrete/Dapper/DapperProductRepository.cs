using NorthwindAPI.Domain.Entities.Concrete;
using NorthwindAPI.Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindAPI.Infrastructure.Repositories.Concrete.Dapper
{
    public class DapperProductRepository : DapperGenericRepository<Product>, IProductRepository
    {

    }
}
