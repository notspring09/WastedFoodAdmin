using System;
using System.Collections.Generic;

namespace WastedFoodSystemAdmin.wasted_food_data
{
    public partial class Report
    {
        public int Id { get; set; }
        public int ReporterId { get; set; }
        public int AccusedId { get; set; }
        public string ReportText { get; set; }
        public string ReportImage { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
