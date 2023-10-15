using NorthwindAPI.Core.Entities.Concrete;
using NorthwindAPI.Core.Results.Abstract;
using NorthwindAPI.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindAPI.DAL.Repositories.Concrete.Dapper
{
    public class DapperEmployeeRepository : DapperGenericRepository<Employee>, IEmployeeRepository
    {
        public async Task<IResult<Employee>> GetByOrderId(int id)
        {
            var query = $"SELECT {GetColumns(tableAs: "e")} FROM {GetTableName(tableAs: "e")}, {GetTableName(entityType: typeof(Order), tableAs: "o")}  where o.OrderID = {id} and o.EmployeeID = e.EmployeeID";
            return await QueryAsync(query);
        }
    }
}
