using famiLYNX.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace famiLYNX.Domain {
    public class Conversation {
        public int Id { get; set; }
        public string Topic { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool IsEvent { get; set; }
        public bool Recurs { get; set; }  // Maybe set up an option to have an event recur to remind the organizer.

        public Family WhichFam { get; set; }
        public ApplicationUser CreatedBy { get; set; }

        public IList<ConversationsVisibleToMembers> VisibleTo { get; set; }
        public IList<ConversationsAttendedByMembers> Attenders { get; set; }
        public IList<Message> MessageList { get; set; }
    }
}