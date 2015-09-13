using famiLYNX.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace famiLYNX.Domain {
    public class InviteOrPlea {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public Response UserResponse { get; set; }
        public Response Approved { get; set; }
        
        public ApplicationUser Pleader { get; set; }
        public ApplicationUser Inviter { get; set; }
        public ApplicationUser Approver { get; set; }

        public Family Family { get; set; }
    }

    public enum Response {
        None,
        Yes,
        No
    }
}