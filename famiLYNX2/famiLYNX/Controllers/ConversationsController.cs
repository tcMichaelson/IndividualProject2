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
    public class ConversationsController : Controller
    {
        private Services.Services _service;

        public ConversationsController(Services.Services service) {
            _service = service;
        }
        // GET: Conversations

        public void StartNewConversation() {
            //This will need a separate view.  It will need a view for topic, event information, expiration dates,
            //recurrence info (which will also need customizable fields).
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplayConversation(int conversationId, int familyId, string familyName, string userName) {
            return PartialView("_Conversation", _service.GetConversationData(conversationId, familyId, familyName, userName));
        }

        // GET: Conversations/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Conversations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Conversations/Create
        [HttpPost]
        public ActionResult Create(CreateConversationViewModel model)
        {
            try {
                // TODO: Add insert logic here
                if (ModelState.IsValid) {
                    _service.CreateConversation(model);
                }
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index", "Familys", new { userID = model.UserName, famName = _service.GetFamilyNameById(model.FamId) });  //View model should
                                                                                                                                              //not have id
        }

        // GET: Conversations/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Conversations/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Conversations/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Conversations/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
