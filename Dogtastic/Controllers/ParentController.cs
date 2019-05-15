using Dogtastic.Services;
using Dogtastic.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dogtastic.Controllers
{
    [Authorize]
    public class ParentController : Controller
    {
        // GET: Parent
        public ActionResult Index()
        {
            //var model = new ParentListItem[0];

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ParentService(userId);
            var model = service.GetParent();

            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ParentCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateParentService();

            if (service.CreateParent(model))
            {
                TempData["SaveResult"] = "You are signed up!.";
                return RedirectToAction("Index");

            };

            ModelState.AddModelError("", "You could not be signed up.");


            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateParentService();
            var model = svc.GetParentByID(id);
            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var service = CreateParentService();
            var detail = service.GetParentByID(id);
            var model =
                new ParentEdit
                {
                    UserID = detail.UserID,
                    ParentID = detail.ParentID,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Zipcode = detail.Zipcode,
                    NumberOfEventsAttended = detail.NumberOfEventsAttended,
                    NumberOfDogsOwned = detail.NumberOfDogsOwned
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ParentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ParentID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateParentService();

            if (service.UpdateParent(model))
            {
                TempData["SaveResult"] = "You are signed up!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "You could not be signed up.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateParentService();
            var model = svc.GetParentByID(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateParentService();

            service.DeleteParent(id);

            TempData["SaveResult"] = "You have been removed";

            return RedirectToAction("Index");
        }

        private ParentService CreateParentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ParentService(userId);
            return service;
        }
    }
}

