﻿using famiLYNX.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace famiLYNX.Presentation.Web {
    public class FamilyViewModel {
        public List<ConversationDTO> ConversationList { get; set; }
        public int FamilyId { get; set; }
        public string FamilyName { get; set; }
        public string UserName { get; set; }
    }
}