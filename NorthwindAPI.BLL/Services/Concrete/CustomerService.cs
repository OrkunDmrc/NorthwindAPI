using NorthwindAPI.BLL.Services.Abstract;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;

namespace NorthwindAPI.BLL.Services.Concrete
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
