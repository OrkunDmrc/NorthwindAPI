﻿using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;

namespace NorthwindAPI.BLL.Services.Abstract
{
    public interface IOrderService : IService<Order>
    {
        Task<IResult<IEnumerable<Order>>> GetAllByShipViaAsync(int id);
    }
}
