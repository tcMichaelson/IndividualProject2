using famiLYNX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace famiLYNX.Domain{
    public class Family {
        public int Id { get; set; }
        public string FamilyUserName { get; set; }
        public string OrgName { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        public FamilyType Type { get; set; }
        public List<ApplicationUser> MemberList { get; set; }
        public List<Conversation> ConversationList { get; set; }
    }
}