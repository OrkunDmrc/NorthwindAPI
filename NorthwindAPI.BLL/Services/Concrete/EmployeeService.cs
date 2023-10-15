using NorthwindAPI.BLL.Services.Abstract;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindAPI.BLL.Services.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<IResult<Employee>> DeleteAsync(int id)
        {
            return await _employeeRepository.DeleteAsync(id);
        }

        public async Task<IResult<Employee>> GetAsync(int id)
        {
            return await _employeeRepository.GetAsync(id);
        }

        public async Task<IResult<IEnumerable<Employee>>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<IResult<Employee>> InsertAsync(Employee entity)
        {
            return await _employeeRepository.InsertAsync(entity);
        }

        public async Task<IResult<Employee>> UpdateAsync(Employee entity)
        {
            return await _employeeRepository.UpdateAsync(entity);
        }

        public async Task<IResult<Employee>> GetByOrderId(int id)
        {
            return await _employeeRepository.GetByOrderId(id);
        }
    }
}
