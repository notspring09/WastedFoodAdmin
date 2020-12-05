using System;
using System.Collections.Generic;

namespace WastedFoodSystemAdmin.wasted_food_data
{
    public partial class Product
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double OriginalPrice { get; set; }
        public double SellPrice { get; set; }
        public int OriginalQuantity { get; set; }
        public int RemainQuantity { get; set; }
        public string Description { get; set; }
        public DateTime SellDate { get; set; }
        public string Status { get; set; }
        public byte? Shippable { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
