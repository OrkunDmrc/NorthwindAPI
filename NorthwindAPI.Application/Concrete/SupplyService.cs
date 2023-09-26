using NorthwindAPI.Application.Abstract;
using NorthwindAPI.Domain.Entities.Concrete;
using NorthwindAPI.Domain.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindAPI.Application.Concrete
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
