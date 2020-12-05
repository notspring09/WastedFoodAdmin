using System;
using System.Collections.Generic;

namespace WastedFoodSystemAdmin.wasted_food_data
{
    public partial class ListFollow
    {
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
        public byte IsFollow { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
