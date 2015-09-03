using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace famiLYNX.Services {
    public class FamilyDTO {
        public string OrgName { get; set; }
        public FamilyTypeDTO Type { get; set; } //family, troop, roommates, church, business, friends
        public List<MemberDTO> MemberList { get; set; }
        public List<ConversationDTO> ConversationList { get; set; }
    }
}