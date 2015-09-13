using famiLYNX.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace famiLYNX.Domain {
    public class FamilyUser {
        public int Id { get; set; }

        [ForeignKey("Family")]
        public int FamilyId { get; set; }
        public Family Family { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}