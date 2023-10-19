using NorthwindAPI.Models.Abstract;

namespace NorthwindAPI.Models.Concrete.TerritoryModels
{
    public class AddTerritoryVM : IViewModel
    {
        public string TerritoryDescription { get; set; } = null!;
        public string RegionId { get; set; }
    }
}
