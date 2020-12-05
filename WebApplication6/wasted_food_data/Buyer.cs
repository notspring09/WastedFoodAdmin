using System;
using System.Collections.Generic;

namespace WastedFoodSystemAdmin.wasted_food_data
{
    public partial class Buyer
    {
        public int AccountId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Image { get; set; }
        public byte? Gender { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Name { get; set; }
    }
}
