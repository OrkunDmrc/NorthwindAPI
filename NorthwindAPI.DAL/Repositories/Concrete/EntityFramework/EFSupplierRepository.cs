using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Concrete.EntityFramework
{
    public class EFSupplierRepository : EFGenericRepository<Supplier, int, NorthwindContext>, ISupplierRepository
    {
        public async Task<IResult<Supplier>> GetByProductId(int id)
        {
            return await GetAsync(s => s.Products.Any(p => p.ProductId == id));
        }
    }
}
