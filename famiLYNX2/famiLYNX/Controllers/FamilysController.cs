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
            FamilyViewModel vm = _service.GetConversations(userID, famName);
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

    }

}
