﻿using NorthwindAPI.Models.Abstract;

namespace NorthwindAPI.Models.Concrete.ShipperModels
{
    public class DeleteShipperVM : IViewModel
    {
        public int ShipperId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string? Phone { get; set; }
    }
}
