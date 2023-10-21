using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Abstract
{
    public interface IEmployeeRepository : IGenericRepository<Employee, int>
    {
        Task<IResult<Employee>> GetByOrderIdAsync(int id);
        Task<IResult<IEnumerable<Employee>>> GetAllByTeritoryIdAsync(string id);
    }
}
