using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Concrete.EntityFramework
{
    public class EFTerritoryRepository : EFGenericRepository<Territory, string, NorthwindContext>, ITerritoryRepository
    {
        public async Task<IResult<IEnumerable<Territory>>> GetAllByEmployeeIdAsync(int id)
        {
            return await GetAllAsync(t => t.Employees.Any(e => e.EmployeeId == id));
        }

        public async Task<IResult<IEnumerable<Territory>>> GetAllByRegionIdAsync(int id)
        {
            return await GetAllAsync(t => t.RegionId == id);
        }
    }
}
