using NorthwindAPI.Application.Abstract;
using NorthwindAPI.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindAPI.Application.Concrete
{
    public class SupplyService : ISupplyService
    {
        public Task DeleteAsync(Supply entity)
        {
            throw new NotImplementedException();
        }

        public Task<Supply> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Supply>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Supply> InsertAsync(Supply entity)
        {
            throw new NotImplementedException();
        }

        public Task<Supply> UpdateAsync(int id, Supply entity)
        {
            throw new NotImplementedException();
        }
    }
}
