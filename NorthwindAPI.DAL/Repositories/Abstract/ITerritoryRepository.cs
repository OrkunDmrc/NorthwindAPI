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
    public interface ITerritoryRepository : IGenericRepository<Territory, string>
    {
        Task<IResult<IEnumerable<Territory>>> GetAllByRegionIdAsync(int id);
    }
}
