using System;
using System.Collections.Generic;

namespace WastedFoodSystemAdmin.wasted_food_data
{
    public partial class Admin
    {
        public int AccountId { get; set; }
        public string Image { get; set; }
        public int SecurityLevel { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
