using famiLYNX.Models;
using famiLYNX.Presentation.Web;
using famiLYNX.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace famiLYNX.Controllers
{
    [Authorize]
    public class FamilysController : Controller {
        private Services.Services _service;

        public FamilysController(Services.Services service) {
            _service = service;
        }

        public ActionResult Index(string userID, string famName) {
            FamilyViewModel vm = _service.PopulateFamilyViewModel(userID, famName);
            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(string orgName, string famUserName="") {
            if(_service.CreateFamily(orgName, User.Identity.Name, famUserName)) {
                return RedirectToAction("MyProfile", "Members");
            }
            return RedirectToAction("MyProfile", "Members");
        }

        public ActionResult IndexNewConversation(string userID, string famName) {
            return View();
        }

        public ActionResult Plea(string famUserName) {
            var currName = _service.GetMemberByUserName(User.Identity.Name);
            string response = _service.ManageInviteOrPleas(famUserName, currName.Email, User.Identity.Name, Services.Response.None, Services.Response.Yes);            
            return RedirectToAction("MyProfile","Members", new { message = response });
        }
        
        public ActionResult ApprovePlea(ManagePleasViewModel model) {
            string response = _service.ManageInviteOrPleas(model.FamilyUserName, model.Email, User.Identity.Name,Services.Response.Yes);
            return RedirectToAction("MyProfile", "Members", new { message = response } );
        }

        public ActionResult DenyPlea(ManagePleasViewModel model) {
            string response = _service.ManageInviteOrPleas(model.FamilyUserName, model.Email, User.Identity.Name, Services.Response.No, Services.Response.No);
            return RedirectToAction("MyProfile", "Members", new { message = response });
        }

    }

}
