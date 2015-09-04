using famiLYNX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace famiLYNX.Domain {
    public class Conversation {
        public int Id { get; set; }
        public string Topic { get; set; }
        public DateTime CreatedDate { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool IsEvent { get; set; }
        public bool Recurs { get; set; }  // Maybe set up an option to have an event recur to remind the organizer.
        public IList<Message> MessageList { get; set; }
        public IList<ApplicationUser> VisibleTo { get; set; }
        public IList<ApplicationUser> AttenderList { get; set; }
        public Family WhichFam { get; set; }
    }
}