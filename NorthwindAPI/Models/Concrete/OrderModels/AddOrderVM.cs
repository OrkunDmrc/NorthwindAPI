using NorthwindAPI.Models.Abstract;

namespace NorthwindAPI.Models.Concrete.OrderModels
{
    public class AddOrderVM : IViewModel
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
    }
}
