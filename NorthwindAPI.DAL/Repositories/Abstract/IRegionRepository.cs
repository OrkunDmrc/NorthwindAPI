using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindAPI.DAL.Repositories.Abstract
{
    public interface IRegionRepository : IGenericRepository<Region, int>
    {
        Task<IResult<Region>> GetByTeritoryIdAsync(string id);
    }
}
