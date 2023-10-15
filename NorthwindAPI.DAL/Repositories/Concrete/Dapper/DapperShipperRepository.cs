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
    public class DapperShipperRepository : DapperGenericRepository<Shipper, int>, IShipperRepository
    {
        public async Task<IResult<Shipper>> GetAllByOrderId(int id)
        {
            var query = $"SELECT {GetColumns(tableAs: "s")} FROM {GetTableName(tableAs: "s")}, {GetTableName(entityType: typeof(Order), tableAs: "o")}  where o.OrderID = {id} and s.ShipperID = o.ShipVia";
            return await QueryAsync(query);
        }
    }
}
