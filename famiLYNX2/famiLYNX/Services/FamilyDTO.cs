using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace famiLYNX.Services {
    public class FamilyDTO {
        public string FamilyUserName { get; set; }
        public string OrgName { get; set; }
        public ApplicationUserDTO CreatedBy { get; set; }
        public FamilyTypeDTO Type { get; set; }

        public IList<InviteOrPleaDTO> InviteOrPleas { get; set; }
        public IList<FamilyUserDTO> MemberList { get; set; }
        public IList<ConversationDTO> ConversationList { get; set; }
    }
}