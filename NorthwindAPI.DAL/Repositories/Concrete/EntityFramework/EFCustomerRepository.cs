using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Concrete.EntityFramework
{
    public class EFCustomerRepository : EFGenericRepository<Customer, string, NorthwindContext>, ICustomerRepository
    {
        public async Task<IResult<Customer>> DeleteAsync(string id)
        {
            return await DeleteAsync(c => c.CustomerId == id);
        }

        public async Task<IResult<Customer>> GetAsync(string id)
        {
            return await GetAsync(c => c.CustomerId == id);
        }

        public async Task<IResult<Customer>> GetByOrderIdAsync(int id)
        {
            return await GetAsync(c => c.Orders.Any(o => o.OrderId == id));
        }
    }
}
