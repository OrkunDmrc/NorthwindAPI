using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Concrete.Dapper
{
    public class DapperTerritoryRepository : DapperGenericRepository<Territory, string>, ITerritoryRepository
    {
        public async Task<IResult<IEnumerable<Territory>>> GetAllByEmployeeIdAsync(int id)
        {
            var query = $"SELECT {GetColumns(tableAs: "t")} FROM {GetTableName(tableAs: "t")}" +
                        $"JOIN {GetTableName(entityType: typeof(EmployeeTerritorry), tableAs: "et")} on t.TerritoryID = et.TerritoryID" +
                        $"where et.EmployeeID = {id}";
            return await QueryListAsync(query);
        }

        public async Task<IResult<IEnumerable<Territory>>> GetAllByRegionIdAsync(int id)
        {
            var query = $"SELECT * FROM {GetTableName()} where RegionID = {id}";
            return await QueryListAsync(query);
        }
    }
}
