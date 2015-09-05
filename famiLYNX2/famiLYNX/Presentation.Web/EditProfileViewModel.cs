using famiLYNX.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace famiLYNX.Presentation.Web {
    public class EditProfileViewModel {
        public ApplicationUserDTO User { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public StName State { get; set; }
        public string Zip { get; set; }
    }
}