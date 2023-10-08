using NorthwindAPI.Models.Abstract;

namespace NorthwindAPI.Models.Concrete.CategoryModels
{
    public class AddCategoryVM : IViewModel
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
    }
}
