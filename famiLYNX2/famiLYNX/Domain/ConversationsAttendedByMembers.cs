using famiLYNX.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace famiLYNX.Domain {
    public class ConversationsAttendedByMembers {
        public int Id { get; set; }

        [ForeignKey("Member")]
        public string MemberId { get; set; }
        public ApplicationUser Member { get; set; }

        [ForeignKey("Conversation")]
        public int ConversationId { get; set; }
        public Conversation Conversation { get; set; }
    }
}