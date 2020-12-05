using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Models
{
    public class AccountSellerViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string ThirdPartyId { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte IsActive { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string FirebaseUid { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
    }
}
