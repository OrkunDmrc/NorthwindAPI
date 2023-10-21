using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindAPI.BLL.Services.Abstract
{
    public interface IRegionService : IService<Region, int>
    {
        Task<IResult<Region>> GetByTeritoryIdAsync(string id);
    }
}
