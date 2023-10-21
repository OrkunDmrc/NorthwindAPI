using Dapper;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;
using System.Data.SqlClient;

namespace NorthwindAPI.DAL.Repositories.Concrete.Dapper
{
    public class DapperProductRepository : DapperGenericRepository<Product, int>, IProductRepository
    {
        public async Task<IResult<IEnumerable<Product>>> GetAllByCategoryIdAsync(int id)
        {
            string query = $"SELECT * FROM {GetTableName()} where CategoryId = {id}";
            return await QueryListAsync(query);
        }

        public async Task<IResult<IEnumerable<Product>>> GetAllBySupplierIdAsync(int id)
        {
            string query = $"SELECT * FROM {GetTableName()} where SupplierId = {id}";
            return await QueryListAsync(query);
        }
    }
}
