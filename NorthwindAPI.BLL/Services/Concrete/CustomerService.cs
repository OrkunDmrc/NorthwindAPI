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
        public Task<IResult<Customer>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult<Customer>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<IResult<List<Customer>>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IResult<Customer>> InsertAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult<Customer>> UpdateAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult<Customer>> GetByOrderId(int id)
        {
            return await _customerRepository.GetByOrderId(id);
        }
    }
}
