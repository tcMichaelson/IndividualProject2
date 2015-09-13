using famiLYNX.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace famiLYNX.Presentation.Web {
    public class ProfileViewModel {
        public ApplicationUserDTO User { get; set; }
        public List<FamilyDTO> Familys { get; set; }        
    }
}