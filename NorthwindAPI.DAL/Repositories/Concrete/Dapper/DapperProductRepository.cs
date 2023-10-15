using Dapper;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;
using System.Data.SqlClient;

namespace NorthwindAPI.DAL.Repositories.Concrete.Dapper
{
    public class DapperProductRepository : DapperGenericRepository<Product>, IProductRepository
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

        public async Task<IResult<IEnumerable<Product>>> GetAllWithCategoryAsync()
        {
            string query = $"SELECT {GetColumns(tableAs: "p")}, {GetColumns(entityType: typeof(Category), tableAs: "c")} FROM {GetTableName(tableAs: "p")}, {GetTableName(entityType: typeof(Category), tableAs: "c")} where c.CategoryId = p.CategoryId";
            try
            {
                await using var connection = new SqlConnection(connectionString);
                var result = await connection.QueryAsync<Product, Category, Product>(query, (product, category) =>
                {
                    product.Category = category;
                    return product;
                },
                splitOn: "CategoryId");
                return resultList.FillSuccessResult(result.ToList());
            }
            catch (Exception ex)
            {
                return resultList.FillUnsuccessResult(ex.Message);
            }
        }
    }
}
