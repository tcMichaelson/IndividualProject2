using famiLYNX.Presentation.Web;
using famiLYNX.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace famiLYNX.Controllers
{
    public class MessagesController : Controller
    {
        private Services.Services _service;

        public MessagesController(Services.Services service) {
            _service = service;
        }

        // GET: Messages
        public ActionResult Index()
        {
            return View();
        }


        // GET: Messages/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Messages/Create
        public ActionResult Create(FamilyViewModel model)
        {
            return View();
        }

        // POST: Messages/Create
        [HttpPost]
        public ActionResult Create(CreateMessageViewModel model)
        {
            try {
                if (ModelState.IsValid) {
                    if (model.MessageText != "" && model.MessageText != null) {
                        _service.CreateMessage(model.MessageText, model.MemberUserName, model.ConversationId);  //no ids in vm
                    }
                }
            }
            catch {
            }
            return RedirectToAction("Index", "Familys", new { userID = model.MemberUserName, famName = _service.GetFamilyNameById(model.FamilyId) });// no ids in vm
        }

        // GET: Messages/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Messages/Edit/5
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

        // GET: Messages/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Messages/Delete/5
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
