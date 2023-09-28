using NorthwindAPI.BLL.Services.Abstract;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;

namespace NorthwindAPI.BLL.Services.Concrete
{
    public class SupplyService : ISupplyService
    {
        public Task<IResult<Supply>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult<Supply>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult<List<Supply>>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IResult<Supply>> InsertAsync(Supply entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult<Supply>> UpdateAsync(int id, Supply entity)
        {
            throw new NotImplementedException();
        }
    }
}
