using NorthwindAPI.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindAPI.Core.Entities.Concrete
{
    [Table("Categories")]
    public class Category : IEntity
    {
        [Key]
        [Column("CategoryID")]
        public int CategoryID { get; set; }
        [Column("CategoryName")]
        public string CategoryName { get; set; }
        [Column("Descripion")]
        public string Descripion { get; set; }
        [Column("Picture")]
        public byte[] Picture { get; set; }
    }
}
