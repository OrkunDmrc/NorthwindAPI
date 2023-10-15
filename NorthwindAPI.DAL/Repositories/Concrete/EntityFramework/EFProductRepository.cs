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

        public async Task<IResult<IEnumerable<Product>>> GetAllWithCategoryAsync()
        {
            try
            {
                using (var context = new NorthwindContext())
                {
                    var result2 = (from p in context.Products
                                   join c in context.Categories on p.CategoryId equals c.CategoryId
                                   select new Product
                                   {
                                       ProductId = p.ProductId,
                                       CategoryId = p.CategoryId,
                                       ProductName = p.ProductName,
                                       SupplierId = p.SupplierId,
                                       QuantityPerUnit = p.QuantityPerUnit,
                                       UnitPrice = p.UnitPrice,
                                       UnitsInStock = p.UnitsInStock,
                                       ReorderLevel = p.ReorderLevel,
                                       Discontinued = p.Discontinued,
                                       Category = c,
                                   }).ToList();
                    return resultList.FillSuccessResult(result2);
                }
            }
            catch (Exception ex)
            {
                return resultList.FillUnsuccessResult(ex.Message);
            }
        }
    }
}
