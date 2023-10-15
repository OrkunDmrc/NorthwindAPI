using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repository.Abstract;

namespace NorthwindAPI.DAL.Repositories.Abstract
{
    public interface ISupplierRepository : IGenericRepository<Supplier, int>
    {
        Task<IResult<Supplier>> GetByProductId(int id);
    }
}
