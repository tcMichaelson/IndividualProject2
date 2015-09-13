using famiLYNX.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace famiLYNX.Domain {
    public class Message {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime TimeSubmitted { get; set; }

        [ForeignKey("Contributor")]
        public string ContributorId { get; set; }
        public ApplicationUser Contributor { get; set; }

        [ForeignKey("Conversation")]
        public int ConversationID { get; set; }
        public virtual Conversation Conversation { get; set; }
    }
}