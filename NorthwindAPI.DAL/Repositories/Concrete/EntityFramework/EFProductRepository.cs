using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Concrete.EntityFramework
{
    public class EFProductRepository : EFGenericRepository<Product, int, NorthwindContext>, IProductRepository
    {

        public async Task<IResult<IEnumerable<Product>>> GetAllByCategoryIdAsync(int id)
        {
            return await GetAllAsync(p => p.CategoryId == id);
        }

        public async Task<IResult<IEnumerable<Product>>> GetAllBySupplierIdAsync(int id)
        {
            return await GetAllAsync(p => p.SupplierId == id);
        }
    }
}
