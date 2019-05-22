using Dogtastic.Models;
using Dogtastic.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dogtastic.Controllers
{
    [Authorize]
    public class PlaydateController : Controller
    {
        public object TypeOfPlaydate { get; private set; }

        // GET: Playdate
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlaydateService(userId);
            var model = service.GetPlaydates();

            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            var svcDog = CreateDogService();
            var svcParent = CreateParentService();

            ViewBag.DogID = new SelectList(svcDog.GetDogs(), "DogID", "DogName");
            ViewBag.UserID = new SelectList(svcParent.GetParents(), "UserID", "ParentName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlaydateCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePlaydateService();

            if (service.CreatePlaydate(model))
            {
                TempData["SaveResult"] = "Your playdete has been created.";
                return RedirectToAction("Index");

            };

            ModelState.AddModelError("", "Your playdate could not be created.");


            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreatePlaydateService();
            var model = svc.GetPlaydatesById(id);
            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var svcDog = CreateDogService();
            var svcParent = CreateParentService();
            ViewBag.DogID = new SelectList(svcDog.GetDogs(), "DogID", "DogName");
            ViewBag.UserID = new SelectList(svcParent.GetParents(), "UserID", "ParentName");

            var service = CreatePlaydateService();
            var detail = service.GetPlaydatesById(id);
            var model =
                new PlaydateEdit
                {
                    UserID = detail.UserID,
                    PlaydateID = detail.PlaydateID,
                    DogID = detail.DogID,
                    //ParentName = detail.ParentName,
                    //DogName = detail.DogName,
                    //DogSize = detail.DogSize,
                    //AgeLevel = detail.AgeLevel,
                    EventDate = detail.EventDate,
                    Timer = detail.Timer,
                    AddressOfEvent = detail.AddressOfEvent,
                    TypeOfPlaydate = detail.TypeOfPlaydate,
                    LeaveAMessage = detail.LeaveAMessage
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PlaydateEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PlaydateID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreatePlaydateService();

            if (service.UpdatePlaydate(model))
            {
                TempData["SaveResult"] = "Your playdate has been created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your playdate could not be created.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreatePlaydateService();
            var model = svc.GetPlaydatesById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePlaydateService();

            service.DeletePlaydate(id);

            TempData["SaveResult"] = "Your playdate has been removed";

            return RedirectToAction("Index");
        }

        private PlaydateService CreatePlaydateService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlaydateService(userId);
            return service;
        }

        private DogService CreateDogService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DogService(userId);
            return service;
        }
        private ParentService CreateParentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ParentService(userId);
            return service;
        }
    }
}
