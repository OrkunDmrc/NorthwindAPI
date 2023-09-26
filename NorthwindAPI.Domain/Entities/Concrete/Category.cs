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
