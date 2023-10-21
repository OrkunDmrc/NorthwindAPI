using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Concrete.Dapper
{
    public class DapperRegionRepository : DapperGenericRepository<Region, int>, IRegionRepository
    {
        public async Task<IResult<Region>> GetByTeritoryIdAsync(string id)
        {
            var query = $"SELECT {GetColumns(tableAs: "r")} FROM {GetTableName(tableAs: "r")}, {GetTableName(entityType: typeof(Territory), tableAs: "t")}  where t.TerritoryID = '{id}' and r.RegionID = t.RegionID";
            return await QueryAsync(query);
        }
    }
}
