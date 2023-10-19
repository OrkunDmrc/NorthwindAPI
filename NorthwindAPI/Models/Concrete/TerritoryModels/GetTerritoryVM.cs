﻿using NorthwindAPI.Models.Abstract;

namespace NorthwindAPI.Models.Concrete.TerritoryModels
{
    public class GetTerritoryVM : IViewModel
    {
        public string TerritoryId { get; set; } = null!;
        public string TerritoryDescription { get; set; } = null!;
        public string RegionId { get; set; }
    }
}
