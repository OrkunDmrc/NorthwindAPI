using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Concrete.EntityFramework
{
    public class EFEmployeeRepository : EFGenericRepository<Employee, int, NorthwindContext>, IEmployeeRepository
    {
        public async Task<IResult<IEnumerable<Employee>>> GetAllByTeritoryIdAsync(string id)
        {
            return await GetAllAsync(e => e.Territories.Any(t => t.TerritoryId == id));
        }

        public async Task<IResult<Employee>> GetByOrderIdAsync(int id)
        {
            return await GetAsync(e => e.Orders.Any(o => o.OrderId == id));
        }
    }
}
