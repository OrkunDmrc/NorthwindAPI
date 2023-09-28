using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.DAL.Repository.Abstract;

namespace NorthwindAPI.DAL.Repositories.Abstract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
