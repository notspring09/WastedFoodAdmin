using System;
using System.Collections.Generic;

namespace WastedFoodSystemAdmin.wasted_food_data
{
    public partial class Order
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public double TotalCost { get; set; }
        public int? BuyerRating { get; set; }
        public string BuyerComment { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
