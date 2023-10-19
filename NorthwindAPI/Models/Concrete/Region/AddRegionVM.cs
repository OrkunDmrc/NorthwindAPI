using NorthwindAPI.Models.Abstract;

namespace NorthwindAPI.Models.Concrete.Region
{
    public class AddRegionVM : IViewModel
    {
        public string RegionDescription { get; set; } = null!;
    }
}
