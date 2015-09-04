using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace famiLYNX.Services {
    public class MessageDTO {
        public string Text { get; set; }
        public ApplicationUserDTO Contributor { get; set; }
        public DateTime TimeSubmitted { get; set; }
        public ConversationDTO Conversation { get; set; }
    }
}