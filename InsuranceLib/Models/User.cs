using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace InsuranceLib.DAL.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public string Address { get; set; }
        public int Pincode { get; set; }
        public string Nominee { get; set; }
        public string NomineeRelation { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public string ParentId { get; set; }
    }
}
