using NorthwindAPI.Application.Abstract;
using NorthwindAPI.Domain.Entities.Concrete;
using NorthwindAPI.Domain.Results.Abstract;

namespace NorthwindAPI.Application.Concrete
{
    public class CustomerService : ICustomerService
    {
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

        public Task<IResult<Customer>> UpdateAsync(int id, Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
