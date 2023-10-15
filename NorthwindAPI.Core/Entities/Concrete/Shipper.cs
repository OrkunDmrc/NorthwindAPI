using NorthwindAPI.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindAPI.Core.Entities.Concrete
{
    [Table("Shippers")]
    public class Shipper : IEntity
    {
        [Key]
        [Column("ShipperID")]
        public int ShipperId { get; set; }
        [Column("CompanyName")]
        public string CompanyName { get; set; } = null!;
        [Column("Phone")]
        public string? Phone { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
