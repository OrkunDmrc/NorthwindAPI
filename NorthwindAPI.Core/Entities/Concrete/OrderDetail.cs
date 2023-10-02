using NorthwindAPI.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindAPI.Core.Entities.Concrete
{
    [Table("OrderDetail")]
    public class OrderDetail : IEntity
    {
        [Key]
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Column("UnitPrice")]
        public decimal UnitPrice { get; set; }
        [Column("Quantity")]
        public short Quantity { get; set; }
        [Column("Discount")]
        public float Discount { get; set; }
        public virtual Order Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
