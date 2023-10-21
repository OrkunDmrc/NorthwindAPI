using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Concrete.EntityFramework
{
    public class EFRegionRepository : EFGenericRepository<Region, int, NorthwindContext>, IRegionRepository
    {
        public async Task<IResult<Region>> GetByTeritoryIdAsync(string id)
        {
            return await GetAsync(r => r.Territories.Any(t => t.TerritoryId == id));
        }
    }
}
