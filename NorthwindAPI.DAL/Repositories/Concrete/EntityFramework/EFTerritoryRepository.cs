using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindAPI.DAL.Repositories.Concrete.EntityFramework
{
    public class EFTerritoryRepository : EFGenericRepository<Territory, string, NorthwindContext>, ITerritoryRepository
    {
        public async Task<IResult<IEnumerable<Territory>>> GetAllByRegionIdAsync(int id)
        {
            return await GetAllAsync(t => t.RegionId == id);
        }
    }
}
