using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;

namespace NorthwindAPI.DAL.Repositories.Concrete.Dapper
{
    public class DapperCustomerRepository : DapperGenericRepository<Customer>, ICustomerRepository
    {
        public async Task<IResult<Customer>> GetByOrderId(int id)
        {
            var query = $"SELECT {GetColumns(tableAs: "c")} FROM {GetTableName(tableAs: "c")}, {GetTableName(entityType: typeof(Order), tableAs: "o")}  where o.OrderId = {id} and c.CustomerId = o.CustomerId";
            return await QueryAsync(query);
        }
    }
}
