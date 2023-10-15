using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindAPI.BLL.Services.Abstract
{
    public interface IShipperService : IService<Shipper>
    {
        Task<IResult<Shipper>> GetByOrderId(int id);
    }
}
