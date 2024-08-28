using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Food_Collection_And_Supply.Models
{
    public class FoodViewModel
    {
        public int Id { get; set; }
        public int DonatedBy { get; set; }
        public string DonatedUserEmail { get; set; }
        public string FoodName { get; set; }
        public string Quantity { get; set; }
        public string ManufacturedDate { get; set; }
        public string ExpiryDate { get; set; }
        public string Status { get; set; }
        public string City { get; set; }
    }
}