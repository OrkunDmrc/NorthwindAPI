using NorthwindAPI.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindAPI.Core.Entities.Concrete
{
    [Table("Employees")]
    public class Employee : IEntity
    {
        [Key]
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }
        [Column("LastName")]
        public string LastName { get; set; } = null!;
        [Column("FirstName")]
        public string FirstName { get; set; } = null!;
        [Column("Title")]
        public string? Title { get; set; }
        [Column("TitleOfCourtesy")]
        public string? TitleOfCourtesy { get; set; }
        [Column("BirthDate")]
        public DateTime? BirthDate { get; set; }
        [Column("HireDate")]
        public DateTime? HireDate { get; set; }
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
        [Column("HomePhone")]
        public string? HomePhone { get; set; }
        [Column("Extension")]
        public string? Extension { get; set; }
        [Column("Photo")]
        public byte[]? Photo { get; set; }
        [Column("Notes")]
        public string? Notes { get; set; }
        [Column("ReportsTo")]
        public int? ReportsTo { get; set; }
        [Column("PhotoPath")]
        public string? PhotoPath { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<Territory> Territories { get; set; } = new List<Territory>();
    }
}
