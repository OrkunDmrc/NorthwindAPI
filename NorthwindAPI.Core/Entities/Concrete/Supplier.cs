﻿using NorthwindAPI.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindAPI.Core.Entities.Concrete
{
    [Table("Suppliers")]
    public class Supplier : IEntity
    {
        [Key]
        [Column("SupplierID")]
        public int SupplierId { get; set; }
        [Column("CompanyName")]
        public string? CompanyName { get; set; }
        [Column("ContactName")]
        public string? ContactName { get; set; }
        [Column("ContactTitle")]
        public string? ContactTitle { get; set; }
        [Column("Address")]
        public string? Address { get; set; }
        [Column("City")]
        public string? City { get; set; }
        [Column("Region")]
        public string? Region { get; set; }
        [Column("PostalCode")]
        public string? PostalCode { get; set; }
        [Column("Country")]
        public string? Country { get; set; }
        [Column("Phone")]
        public string? Phone { get; set; }
        [Column("Fax")]
        public string? Fax { get; set; }
        [Column("HomePage")]
        public string? HomePage { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
