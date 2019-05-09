using Dogtastic.Data;
using Dogtastic.Models;
using Dogtastic.Services;
using DogtasticData;
using DogtasticModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dogtastic.Controllers
{
    [Authorize]
    public class DogController : Controller
    {
        // GET: Dog
        public ActionResult Index()
        {
            //var model = new NoteListItem[0];

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DogService(userId);
            var model = service.GetDogs();

            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DogCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateDogService();

            if (service.CreateDog(model))
            {
                TempData["SaveResult"] = "Your dog has been registered.";
                return RedirectToAction("Index");

            };

            ModelState.AddModelError("", "Dog could not be registered.");


            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateDogService();
            var model = svc.GetDogsById(id);
            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var service = CreateDogService();
            var detail = service.GetDogsById(id);
            var model =
                new DogEdit
                {
                    DogName = detail.DogName,
                    DogSize = detail.DogSize,
                    AgeLevel = detail.AgeLevel
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DogEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.DogID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateDogService();

            if (service.UpdateDog(model))
            {
                TempData["SaveResult"] = "Your dog has been registered.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your dog could not be registered.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateDogService();
            var model = svc.GetDogsById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateDogService();

            service.DeleteDog(id);

            TempData["SaveResult"] = "Your dog has been removed";

            return RedirectToAction("Index");
        }

        private DogService CreateDogService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DogService(userId);
            return service;
        }
    }
}

