using NorthwindAPI.BLL.Services.Abstract;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;

namespace NorthwindAPI.BLL.Services.Concrete
{
    public class SupplyService : ISupplyService
    {
        public Task<IResult<Supplier>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult<Supplier>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult<List<Supplier>>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IResult<Supplier>> InsertAsync(Supplier entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult<Supplier>> UpdateAsync(Supplier entity)
        {
            throw new NotImplementedException();
        }
    }
}
