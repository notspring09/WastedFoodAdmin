using System;
using System.Collections.Generic;

namespace WastedFoodSystemAdmin.wasted_food_data
{
    public partial class Seller
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
        public DateTime ModifiedDate { get; set; }
        public double Rating { get; set; }
    }
}
