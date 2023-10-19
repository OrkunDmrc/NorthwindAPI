using NorthwindAPI.Models.Abstract;

namespace NorthwindAPI.Models.Concrete.Region
{
    public class UpdateRegionVM : IViewModel
    {
        public int RegionId { get; set; }
        public string RegionDescription { get; set; } = null!;
    }
}
