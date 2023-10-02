using NorthwindAPI.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindAPI.Core.Entities.Concrete
{
    [Table("Region")]
    public class Region : IEntity
    {
        [Key]
        [Column("RegionID")]
        public int RegionId { get; set; }
        [Column("RegionDescription")]
        public string RegionDescription { get; set; } = null!;
        public virtual ICollection<Territory> Territories { get; set; } = new List<Territory>();
    }
}
