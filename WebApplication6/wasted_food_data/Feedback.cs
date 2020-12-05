using System;
using System.Collections.Generic;

namespace WastedFoodSystemAdmin.wasted_food_data
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string FeedbackText { get; set; }
        public byte IsRead { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Title { get; set; }
    }
}
