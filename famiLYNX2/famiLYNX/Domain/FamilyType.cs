﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//This is primarily used for family roles, but I'm not sure if
//it's really needed for functionality's sake.
namespace famiLYNX.Domain {
    public class FamilyType {
        public int Id { get; set; }
        public string OrgType { get; set; }
    }
}