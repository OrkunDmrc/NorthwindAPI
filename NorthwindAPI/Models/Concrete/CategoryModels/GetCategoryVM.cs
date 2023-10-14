using NorthwindAPI.Models.Abstract;

namespace NorthwindAPI.Models.Concrete.CategoryModels
{
    public class GetCategoryVM : IViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
