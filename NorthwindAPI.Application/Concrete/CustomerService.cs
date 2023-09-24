using NorthwindAPI.Application.Abstract;
using NorthwindAPI.Domain.Entities.Concrete;

namespace NorthwindAPI.Application.Concrete
{
    public class CustomerService : ICustomerService
    {
        public Task DeleteAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> InsertAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> UpdateAsync(int id, Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
