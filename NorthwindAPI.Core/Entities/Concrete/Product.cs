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
        public int ProductID { get; set; }
        [Column("ProductName")]
        public string ProductName { get; set; }
        [Key]
        [Column("SupplierID")]
        public int SupplierID { get; set; }
        [Key]
        [Column("CategoryID")]
        public int CategoryID { get; set; }
        [Column("QuantityPerUnit")]
        public string QuantityPerUnit { get; set; }
        [Column("UnitPrice")]
        public decimal UnitPrice { get; set; }
        [Column("UnitsInStock")]
        public int UnitsInStock { get; set; }
        [Column("UnitsOnOrder")]
        public int UnitsOnOrder { get; set; }
        [Column("ReorderLevel")]
        public int ReorderLevel { get; set; }
        [Column("Discontinued")]
        public bool Discontinued { get; set; }
    }
}
