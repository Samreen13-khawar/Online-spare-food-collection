using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Food_Collection_And_Supply.Models
{
    public class RegisterViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
    }
}