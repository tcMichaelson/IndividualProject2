using famiLYNX.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace famiLYNX.Domain{
    public class Family {
        public int Id { get; set; }
        public string FamilyUserName { get; set; }
        public string OrgName { get; set; }

        public ApplicationUser CreatedBy { get; set; }
        public FamilyType Type { get; set; }

        //Navigation Properties
        public IList<InviteOrPlea> InviteOrPleas { get; set; }
        public IList<FamilyUser> MemberList { get; set; }
        public IList<Conversation> ConversationList { get; set; }
    }
}