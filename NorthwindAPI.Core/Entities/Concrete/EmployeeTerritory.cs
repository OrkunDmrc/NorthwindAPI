using NorthwindAPI.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;
namespace NorthwindAPI.Core.Entities.Concrete
{
    [Table("EmployeeTerritories")]
    public class EmployeeTerritorry : IEntity
    {
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }
        [Column("TerritoryID")]
        public string TerritoryId { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
        public virtual Territory Territory { get; set; } = null!;
    }
}
