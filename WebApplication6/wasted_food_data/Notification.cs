using System;
using System.Collections.Generic;

namespace WastedFoodSystemAdmin.wasted_food_data
{
    public partial class Notification
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Content { get; set; }
        public int OrderId { get; set; }
        public byte Seen { get; set; }
    }
}
