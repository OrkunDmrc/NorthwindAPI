using NorthwindAPI.Models.Abstract;

namespace NorthwindAPI.Models.Concrete.OrderModels
{
    public class DeleteOrderVM : IViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
    }
}
