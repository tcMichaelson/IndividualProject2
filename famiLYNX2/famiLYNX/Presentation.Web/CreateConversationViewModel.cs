using famiLYNX.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace famiLYNX.Presentation.Web {
    public class CreateConversationViewModel {
        public int famId { get; set; }  //no id in vm.  Added back in so it would work.
        [Required]
        public string NewTopic { get; set; }
        public string FirstMessage { get; set; }
        public DateTime? ExpirationDate {get;set;}
        public bool IsEvent { get; set; }
        public bool Recurs { get; set; }
        public string UserName { get; set; }
        public int FamId { get; set; }
    }
}