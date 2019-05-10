using Dogtastic.Services;
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

            var userID = Guid.Parse(User.Identity.GetParentID());
            var service = new ParentService(userID);
            var model = service.GetParents();

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
            var model = svc.GetParentById(id);
            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var service = CreateParentService();
            var detail = service.GetParentById(id);
            var model =
                new ParentEdit
                {
                    ParentID = detail.ParentID,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Zipcode = detail.Zipcode,
                    NumberofEventsAttended = detail.NumberOfEventsAttended,
                    NumberOfDogsOwned = detail.NumberOfDogsOwned
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ParentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.DogID != id)
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
            var svc = ParentService();
            var model = svc.GetParentById(id);
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
            var userId = Guid.Parse(User.Identity.GetParentID());
            var service = new ParentService(userId);
            return service;
        }
    }
}

}