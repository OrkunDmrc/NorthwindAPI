using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Concrete.EntityFramework
{
    public class EFCategoryRepository : EFGenericRepository<Category, int, NorthwindContext>, ICategoryRepository
    {
        public async Task<IResult<Category>> GetByProductId(int id)
        {
            return await GetAsync(c => c.Products.Any(p => p.ProductId == id));
        }
    }
}
