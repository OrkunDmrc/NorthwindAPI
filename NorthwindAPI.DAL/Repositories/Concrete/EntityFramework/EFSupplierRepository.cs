using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Concrete.EntityFramework
{
    public class EFSupplierRepository : EFGenericRepository<Supplier, NorthwindContext>, ISupplierRepository
    {
        public async Task<IResult<Supplier>> GetByProductId(int id)
        {
            try
            {
                using (var context = new NorthwindContext())
                {
                    var queryResult = await(from s in context.Suppliers
                                            join p in context.Products on s.SupplierId equals p.SupplierId
                                            where p.ProductId == id
                                            select s).FirstOrDefaultAsync();
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
