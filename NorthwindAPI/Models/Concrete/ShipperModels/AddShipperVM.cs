using NorthwindAPI.Models.Abstract;

namespace NorthwindAPI.Models.Concrete.ShipperModels
{
    public class AddShipperVM : IViewModel
    {
        public string CompanyName { get; set; } = null!;
        public string? Phone { get; set; }
    }
}
