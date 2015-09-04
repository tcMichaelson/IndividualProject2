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
    public class MembersController : Controller
    {
        private Services.Services _service;

        public MembersController(Services.Services service) {
            _service = service;
        }

        // GET: Members
        public ActionResult MyProfile()
        {
            return View(_service.GetMemberByUserName(User.Identity.Name));
        }
    }
}
