using NorthwindAPI.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindAPI.Core.Entities.Concrete
{
    [Table("Products")]
    public class Product : IEntity
    {
        [Key]
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Column("ProductName")]
        public string ProductName { get; set; }
        [Column("SupplierID")]
        public int? SupplierId { get; set; }
        [Column("CategoryID")]
        public int? CategoryId { get; set; }
        [Column("QuantityPerUnit")]
        public string? QuantityPerUnit { get; set; }
        [Column("UnitPrice")]
        public decimal? UnitPrice { get; set; }
        [Column("UnitsInStock")]
        public short? UnitsInStock { get; set; }
        [Column("UnitsOnOrder")]
        public short? UnitsOnOrder { get; set; }
        [Column("ReorderLevel")]
        public short? ReorderLevel { get; set; }
        [Column("Discontinued")]
        public bool Discontinued { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public virtual Supplier? Supplier { get; set; }
    }
}
