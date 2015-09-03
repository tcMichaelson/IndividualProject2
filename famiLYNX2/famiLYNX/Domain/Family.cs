using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace famiLYNX.Domain{
    public class Family {
        public int Id { get; set; }
        public string OrgName { get; set; }
        public FamilyType Type { get; set; } //family, troop, roommates, church, business, friends
        public List<Member> MemberList { get; set; }
        public List<Conversation> ConversationList { get; set; }
    }
}