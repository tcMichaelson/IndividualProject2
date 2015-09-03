using famiLYNX.Presentation.Web;
using famiLYNX.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace famiLYNX.Controllers
{
    public class FamilysController : Controller {
        private Services.Services _service;

        public FamilysController(Services.Services service) {
            _service = service;
        }

        public ActionResult Index(string userID, string famName) {
            FamilyViewModel vm = _service.GetConversations(userID, famName);
            if (vm.ConversationList != null) {
                return View(vm);
            } else {
                return RedirectToAction("Index", "Login");
            }

        }

        public ActionResult IndexNewConversation(string userID, string famName) {
            return View();
        }

    }

}
