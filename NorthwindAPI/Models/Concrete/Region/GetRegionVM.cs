using NorthwindAPI.Models.Abstract;

namespace NorthwindAPI.Models.Concrete.Region
{
    public class GetRegionVM : IViewModel
    {
        public int RegionId { get; set; }
        public string RegionDescription { get; set; } = null!;
    }
}
