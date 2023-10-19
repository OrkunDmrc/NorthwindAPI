using NorthwindAPI.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindAPI.Core.Entities.Concrete
{
    [Table("Territories")]
    public class Territory : IEntity
    {
        [Key]
        [Column("TerritoryID")]
        public string TerritoryId { get; set; } = null!;
        [Column("TerritoryDescription")]
        public string TerritoryDescription { get; set; } = null!;
        [Column("RegionID")]
        public int RegionId { get; set; }
        public virtual Region Region { get; set; } = null!;
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
