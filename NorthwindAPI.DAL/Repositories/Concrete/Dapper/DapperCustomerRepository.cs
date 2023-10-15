using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Concrete.Dapper
{
    public class DapperCustomerRepository : DapperGenericRepository<Customer, string>, ICustomerRepository
    {
        /*public async Task<IResult<Customer>> DeleteAsync(string id)
        {
            var query = $"DELETE FROM {GetTableName()}  where CustomerID = {id}";
            return await ExecuteAsync(query, null);
        }

        public async Task<IResult<Customer>> GetAsync(string id)
        {
            var query = $"SELECT * FROM {GetTableName()}  where CustomerID = {id}";
            return await QueryAsync(query);
        }*/

        public async Task<IResult<Customer>> GetByOrderIdAsync(int id)
        {
            var query = $"SELECT {GetColumns(tableAs: "c")} FROM {GetTableName(tableAs: "c")}, {GetTableName(entityType: typeof(Order), tableAs: "o")}  where o.OrderId = {id} and c.CustomerId = o.CustomerId";
            return await QueryAsync(query);
        }
    }
}
