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
    public class MembersController : Controller {
        private Services.Services _service;

        public MembersController(Services.Services service) {
            _service = service;
        }

        // GET: Members
        public ActionResult MyProfile() {
            return View(_service.GetProfileViewModel(User.Identity.Name));
        }

        public ActionResult MyProfileEdit() {
            return View(_service.GetEditProfileViewModel(User.Identity.Name));
        }

        [HttpPost]
        public ActionResult MyProfileEdit(EditProfileViewModel model) {

            _service.UpdateUserProfile(model);
            return RedirectToAction("MyProfile");
        }

        [HttpPost]
        public ActionResult UpdateAddress(AddressDTO address) {
            try {
                if (ModelState.IsValid) {
                    var user = new ApplicationUserDTO();
                    _service.UpdateUserAddress(user, address);
                    return RedirectToAction("MyProfileEdit");
                }
                return View();
            } catch {
                return View();
            }
        }

    }
}
