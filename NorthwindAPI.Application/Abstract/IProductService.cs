using NorthwindAPI.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindAPI.Application.Abstract
{
    public interface IProductService : IService<Product>
    {
    }
}
