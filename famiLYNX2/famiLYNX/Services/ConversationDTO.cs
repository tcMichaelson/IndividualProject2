using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace famiLYNX.Services {
    public class ConversationDTO {
        public string Topic { get; set; }
        public DateTime CreatedDate { get; set; }
        public MemberDTO CreatedBy { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool IsEvent { get; set; }
        public bool Recurs { get; set; }  // Maybe set up an option to have an event recur to remind the organizer.
        public IList<MessageDTO> MessageList { get; set; }
        public IList<MemberDTO> VisibleTo { get; set; }
        public IList<MemberDTO> AttenderList { get; set; }
        public FamilyDTO WhichFam { get; set; }
    }
}