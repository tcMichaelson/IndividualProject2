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
            return View(_service.GetMemberByUserName(User.Identity.Name));
        }

        public ActionResult MyProfileEdit() {
            var address = _service.GetUserAddress(User.Identity.Name);
            var user = _service.GetMemberByUserName(User.Identity.Name);
            EditProfileViewModel vm = new EditProfileViewModel() {
                City = address.City,
                State = address.State,
                Street = address.Street,
                Zip = address.Zip,
                User = user
            };
            return View(vm);
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
