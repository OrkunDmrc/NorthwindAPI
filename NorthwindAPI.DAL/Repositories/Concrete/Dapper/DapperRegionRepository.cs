using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindAPI.DAL.Repositories.Concrete.Dapper
{
    public class DapperRegionRepository : DapperGenericRepository<Region, int>, IRegionRepository
    {
    }
}
