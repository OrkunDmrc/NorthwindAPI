using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindAPI.DAL.Repositories.Concrete.Dapper
{
    public class DapperTerritoryRepository : DapperGenericRepository<Territory, string>, ITerritoryRepository
    {
        public async Task<IResult<IEnumerable<Territory>>> GetAllByRegionIdAsync(int id)
        {
            var query = $"SELECT * FROM {GetTableName()} where RegionID = {id}";
            return await QueryListAsync(query);
        }
    }
}
