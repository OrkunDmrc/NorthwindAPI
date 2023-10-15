using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repository.Abstract;

namespace NorthwindAPI.DAL.Repositories.Abstract
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<IResult<Employee>> GetByOrderId(int id);
    }
}
