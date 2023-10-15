using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Concrete.EntityFramework
{
    public class EFOrderRepository : EFGenericRepository<Order, NorthwindContext>, IOrderRepository
    {
    }
}
