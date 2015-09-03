using famiLYNX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace famiLYNX.Domain{
    public class Member : ApplicationUser {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address UserAddress { get; set; }
        public List<Family> Families { get; set; }
        public List<OrgRole> OrgRoles { get; set; }
    }
}