using Dapper;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;
using System.Data.SqlClient;

namespace NorthwindAPI.DAL.Repositories.Concrete.Dapper
{
    public class DapperProductRepository : DapperGenericRepository<Product>, IProductRepository
    {
        public async Task<IResult<List<Product>>> GetListByCategoryIdAsync(int categoryId)
        {
            string query = $"SELECT * FROM {GetTableName()} where CategoryID = {categoryId}";
            return await QueryListAsync(query);
        }

        public async Task<IResult<List<Product>>> GetListWithCategoryAsync()
        {
            string query = $"SELECT {GetColumns(tableAs: "p")}, {GetColumns(entityType: typeof(Category), tableAs: "c")} FROM {GetTableName(tableAs: "p")}, {GetTableName(entityType: typeof(Category), tableAs: "c")} where c.CategoryID = p.CategoryID";
            try
            {
                await using var connection = new SqlConnection(connectionString);
                var result = await connection.QueryAsync<Product, Category, Product>(query, (product, category) =>
                {
                    product.Category = category;
                    return product;
                },
                splitOn: "CategoryID");
                return resultList.FillSuccessResult(result.ToList());
            }
            catch (Exception ex)
            {
                return resultList.FillUnsuccessResult(ex.Message);
            }
        }
    }
}
