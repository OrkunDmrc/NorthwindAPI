using NorthwindAPI.BLL.Services.Abstract;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.BLL.Services.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<IResult<Customer>> DeleteAsync(string id)
        {
            return await _customerRepository.DeleteAsync(id);
        }

        public async Task<IResult<Customer>> GetAsync(string id)
        {
            return await _customerRepository.GetAsync(id);
        }

        public async Task<IResult<IEnumerable<Customer>>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<IResult<Customer>> InsertAsync(Customer entity)
        {
            return await _customerRepository.InsertAsync(entity);
        }

        public async Task<IResult<Customer>> UpdateAsync(Customer entity)
        {
            return await _customerRepository.UpdateAsync(entity);
        }

        public async Task<IResult<Customer>> GetByOrderId(int id)
        {
            return await _customerRepository.GetByOrderIdAsync(id);
        }
    }
}
