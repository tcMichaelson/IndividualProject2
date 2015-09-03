using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace famiLYNX.Services {
    public class MemberDTO {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressDTO UserAddress { get; set; }
        public List<FamilyDTO> Families { get; set; }
        public List<RoleDTO> MemberRoles { get; set; }
    }
}