using Dapper;
using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;
using System.Data.SqlClient;

namespace NorthwindAPI.DAL.Repositories.Concrete.Dapper
{
    public class DapperCategoryRepository : DapperGenericRepository<Category>, ICategoryRepository
    {
        public async Task<IResult<Category>> GetByProductId(int id)
        {
            var query = $"SELECT {GetColumns(tableAs: "c")} FROM {GetTableName(tableAs: "c")}, {GetTableName(entityType: typeof(Product), tableAs: "p")}  where p.ProductID = {id} and c.CategoryID = p.CategoryID";
            return await QueryAsync(query);
            /*try
            {
                await using var connection = new SqlConnection(connectionString);
                var queryResult = await connection.QuerySingleOrDefaultAsync<Category>(query);
                return result.FillSuccessResult(queryResult);
            }
            catch (Exception ex)
            {
                return result.FillUnsuccessResult(ex.Message);
            }*/
        }
    }
}
