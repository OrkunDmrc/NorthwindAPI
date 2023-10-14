﻿using NorthwindAPI.Models.Abstract;

namespace NorthwindAPI.Models.Concrete.OrderDetailModels
{
    public class UpdateOrderDetailVM : IViewModel
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
    }
}
