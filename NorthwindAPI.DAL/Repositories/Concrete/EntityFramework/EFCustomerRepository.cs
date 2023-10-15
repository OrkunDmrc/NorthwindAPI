using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Concrete.EntityFramework
{
    public class EFCustomerRepository : EFGenericRepository<Customer, NorthwindContext>, ICustomerRepository
    {
        public async Task<IResult<Customer>> GetByOrderId(int id)
        {
            try
            {
                using (var context = new NorthwindContext())
                {
                    var queryResult = await (from c in context.Customers
                                             join o in context.Orders on c.CustomerId equals o.CustomerId
                                             where o.OrderId == id
                                             select c).FirstOrDefaultAsync();
                    return result.FillSuccessResult(queryResult);
                }
            }
            catch (Exception ex)
            {
                return result.FillUnsuccessResult(ex.Message);
            }
        }
    }
}
