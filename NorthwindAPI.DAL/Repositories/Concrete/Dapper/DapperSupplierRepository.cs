using Dapper;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;
using System.Data.SqlClient;

namespace NorthwindAPI.DAL.Repositories.Concrete.Dapper
{
    public class DapperSupplierRepository : DapperGenericRepository<Supplier, int>, ISupplierRepository
    {
        public async Task<IResult<Supplier>> GetByProductId(int id)
        {
            string query = $"SELECT {GetColumns(tableAs: "s")} FROM {GetTableName(tableAs: "s")}, {GetTableName(entityType: typeof(Product), tableAs: "p")}  where p.ProductID = {id} and s.SupplierID = p.CategoryID";
            return await QueryAsync(query);
        }
    }
}
