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
    public class DapperEmployeeRepository : DapperGenericRepository<Employee, int>, IEmployeeRepository
    {
        public async Task<IResult<IEnumerable<Employee>>> GetAllByTeritoryIdAsync(string id)
        {
            var query = $"SELECT {GetColumns(tableAs: "e")} FROM {GetTableName(tableAs: "e")}" +
                        $"JOIN {GetTableName(entityType: typeof(EmployeeTerritorry), tableAs: "et")} on e.EmployeeID = et.EmployeeID" +
                        $"where et.TerritoryID = {id}";
            return await QueryListAsync(query);
        }

        public async Task<IResult<Employee>> GetByOrderIdAsync(int id)
        {
            var query = $"SELECT {GetColumns(tableAs: "e")} FROM {GetTableName(tableAs: "e")}, {GetTableName(entityType: typeof(Order), tableAs: "o")}  where o.OrderID = {id} and o.EmployeeID = e.EmployeeID";
            return await QueryAsync(query);
        }
    }
}
