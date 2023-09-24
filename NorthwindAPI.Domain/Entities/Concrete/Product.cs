using NorthwindAPI.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindAPI.Domain.Entities.Concrete
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
