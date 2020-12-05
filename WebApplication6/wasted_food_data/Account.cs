using System;
using System.Collections.Generic;

namespace WastedFoodSystemAdmin.wasted_food_data
{
    public partial class Account
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string ThirdPartyId { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte IsActive { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string FirebaseUid { get; set; }
    }
}
