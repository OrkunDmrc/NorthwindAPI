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
    [Table("Supplies")]
    public class Supply : IEntity
    {
        [Key]
        [Column("SupplierID")]
        public int SupplierID { get; set; }
        [Column("CompanyName")]
        public string CompanyName { get; set; }
        [Column("ContactName")]
        public string ContactName { get; set; }
        [Column("ContactTitle")]
        public string ContactTitle { get; set; }
        [Column("Address")]
        public string Address { get; set; }
        [Column("City")]
        public string City { get; set; }
        [Column("Region")]
        public string Region { get; set; }
        [Column("PostalCode")]
        public string PostalCode { get; set; }
        [Column("Country")]
        public string Country { get; set; }
        [Column("Phone")]
        public string Phone { get; set; }
        [Column("Fax")]
        public string Fax { get; set; }
        [Column("HomePage")]
        public string HomePage { get; set; }
    }
}
