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
            try
            {
                using (var context = new NorthwindContext())
                {
                    var queryResult = await (from c in context.Categories
                                    join p in context.Products on c.CategoryId equals p.CategoryId
                                    where p.ProductId == id
                                    select c).FirstOrDefaultAsync();
                    return result.FillSuccessResult(queryResult);
                }
            }
            catch (Exception ex)
            {
                return result.FillUnsuccessResult(ex.Message);
            }
        }
    }
}
