using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Concrete.EntityFramework
{
    public class EFEmployeeRepository : EFGenericRepository<Employee, int, NorthwindContext>, IEmployeeRepository
    {
        public async Task<IResult<Employee>> GetByOrderId(int id)
        {
            try
            {
                using (var context = new NorthwindContext())
                {
                    var queryResult = await(from e in context.Employees
                                            join o in context.Orders on e.EmployeeId equals o.EmployeeId
                                            where o.OrderId == id
                                            select e).FirstOrDefaultAsync();
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
